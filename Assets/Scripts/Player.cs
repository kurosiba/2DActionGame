using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    //インスペクターで設定する
    [Header("速さ")] public float speed;//速さ
    [Header("重力")] public float gravity;//重力
    [Header("ジャンプの速さ")] public float jumpSpeed;//ジャンプの速さ
    [Header("ジャンプの上限")] public float jumpHeight;//ジャンプの上限
    [Header("滞空時間の制限")] public float jumpLimitTime;//滞空時間の制限
    [Header("踏みつけ判定の高さ")] public float stepOnRate;
    public checkGround ground; //headとgroundで参照するスクリプトを自分で入れるようにしている
    public checkGround head;
    public AnimationCurve dashCurve;//アニメーションカーブ（グラフを書いて数値を制御できるやつ）を使う用
    public AnimationCurve jumpCurve;
    [SerializeField] GameObject GameOverPanel;

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private BoxCollider2D capcoll = null;
    private bool isGround = false;//設置判定
    private bool isRun = false;//走っているかの判定
    private bool isDeath = false;//死亡判定
    private bool isGoal = false;//goal判定
    private bool isJump = false;//ジャンプ判定
    private bool isOtherJump = false;
    private bool isHead = false;//頭の判定
    private float otherJumpHeight = 0.0f;
    private float jumpPos = 0.0f;//ジャンプの位置の記録（ジャンプの上限判定用）
    private float jumpTime, dashTime;//ジャンプの滞空時間記録, 走ってる時間の記録
    private float beforeKey;
    private string enemyTag = "Enemy";
    private string dethLineTag = "DethLine";
    private string goalLineTag = "GoalLine";
    void Start() {

        //インスタンスの取得
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcoll = GetComponent<BoxCollider2D>();

    }

    void FixedUpdate() {
        if (!isDeath) {
            //設置判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //速度を得る
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();


            //アニメーションの適用
            setAnimation();

            rb.velocity = new Vector2(xSpeed, ySpeed);//移動速度の決定(物理演算のはやさを少し、いじっている)
        } else {
            rb.velocity = new Vector2(0, -gravity);//死んだときに動けないようにしてる
        }
    }
    private float GetYSpeed() {

        float ySpeed = -gravity;
        float verticalKey = Input.GetAxis("Vertical");//垂直方向の数値を管理してくれるもの

        //y軸の移動（ジャンプ）t.GetAxis("Vertical");
        if (isGround) {//地面にいるとき
            if (verticalKey > 0 && jumpTime < jumpLimitTime) {//上矢印入力時かつ、滞空時間が既定の時間を超えていないときの処理
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;//ジャンプ始めの記録
                isJump = true;
                jumpTime = 0.0f;
            } else {
                isJump = false;
            }
        } else if (isOtherJump) {
            if (jumpPos + otherJumpHeight > transform.position.y && jumpTime < jumpLimitTime && !isHead) {
                ySpeed = jumpSpeed;
                jumpTime = Time.deltaTime;
            } else {
                isOtherJump = false;
                jumpTime = 0.0f;
            }

        } else if (isJump) { //ジャンプ中
            if (verticalKey > 0 && jumpPos + jumpHeight > transform.position.y && jumpTime < jumpLimitTime && !isHead) {//上入力かつ、上限より下にいるかつ、制限時間内かつ、頭の判定にぶつかっていない
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;//時間をフレーム単位で計測する
            } else {
                isJump = false;
                jumpTime = 0.0f;
            }
        }


            //アニメーションカーブを速度に適用 

            if (isJump) {
                ySpeed *= jumpCurve.Evaluate(jumpTime);
            }

            return ySpeed;
        
    }
    private float GetXSpeed() {

        float horizontalKey = Input.GetAxis("Horizontal");//水平方向の数値を管理してくれるもの
        float xSpeed = 0.0f;


        //x軸の移動
        if (horizontalKey > 0) {//右矢印の入力時
            transform.localScale = new Vector3(1, 1, 1);//アニメーションが右に向くようにしている
            isRun = true;
            xSpeed = speed;
            dashTime += Time.deltaTime;

        } else if (horizontalKey < 0) {//左矢印入力時
            transform.localScale = new Vector3(-1, 1, 1);//アニメーションが左に向くようにしている
            isRun = true;
            xSpeed = -speed;
            dashTime += Time.deltaTime;

        } else {//何も入力していない時
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;

        }

        //前回の入力からダッシュの反転を判断して速度を変える（ジャンプ中に反転した時の処理）
        if (horizontalKey > 0 && beforeKey < 0) {
            dashTime = 0.0f;
        } else if (horizontalKey < 0 && beforeKey > 0) {
            dashTime = 0.0f;
        }

        beforeKey = horizontalKey;//今回の入力を記録

        xSpeed *= dashCurve.Evaluate(dashTime);//横軸に当たるものをとってきてそれを入れることで縦軸の数値が手に入る

        // beforeKey = horizontalKey;

        return xSpeed;
    }
    private void setAnimation() {
        anim.SetBool("run", isRun);//アニメーションの制御
        anim.SetBool("jump", isJump||isOtherJump);
        anim.SetBool("ground", isGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == enemyTag)
        {

            //踏みつけ判定になる高さ
            float stepOnHeight = capcoll.size.y * (stepOnRate / 100f);
            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcoll.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (judgePos > p.point.y)
                {//足元で敵が接触したときの判定
                    objectCollision o = collision.gameObject.GetComponent<objectCollision>();
                    if (o != null)
                    {
                        otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                        o.stepOnPlayer = true;        //踏んづけたものに対して踏んづけた事を通知する
                        isOtherJump = true;
                        isJump = false;
                        jumpTime = 0.0f;
                    }
                    else
                    {
                        Debug.Log("ObjectCollisionが付いてないよ!");
                    }
                }
                else
                {
                    anim.Play("deathAnimation");
                    isDeath = true;
                    GameOverPanel.SetActive(true);
                    break;
                }
            }
        }

            if (collision.collider.tag == dethLineTag)
            {
                anim.Play("deathAnimation");
                isDeath = true;
                GameOverPanel.SetActive(true);
            }
            else
            {
              if (!isDeath)
              {
                  isDeath = false;
              }
              else
              {
                  isDeath = true;
              }
            }

        if (collision.collider.tag == goalLineTag)
        {
            //Debug.Log("ゴールおめでとう！");
            //anim.Play("deathAnimation");
            isGoal = true;
            if (gManager.instance.stageNum == 0)
            {
                gManager.instance.preStageScore = gManager.instance.score;
                gManager.instance.stageNum += 1;
                SceneManager.LoadScene("2StoryScene");
            }else if(gManager.instance.stageNum == 1)
            {
                gManager.instance.stageNum = 0;
                SceneManager.LoadScene("GoalScene");
            }
        }
        else
        {
            if (!isGoal)
            {
                isGoal = false;
            }
            else
            {
                isGoal = true;
            }
        }
    }
    
}