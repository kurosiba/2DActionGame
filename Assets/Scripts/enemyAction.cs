using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAction : MonoBehaviour
{
    //インスペクターで設定する。
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("移動速度")]public float speed;
    [Header("重力")] public float gravity;
    [Header("接触判定")] public enemyCollisionCheck checkCollision;

    //プライベート変数
    private SpriteRenderer sr = null;
    private Rigidbody2D rb = null;
    private Animator anim = null;
    private objectCollision oc = null;
    private BoxCollider2D col = null;
    private bool RightTLeftF = false;
    private bool isDead = false;
    private float deathTimer = 0.0f;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        oc = GetComponent<objectCollision>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!oc.stepOnPlayer) {
            
            if (sr.isVisible || nonVisibleAct) {

                if (checkCollision.isOn) {
                    
                    RightTLeftF = !RightTLeftF;
                }

                int XVector = -1;

                if (RightTLeftF) {
                    XVector = 1;
                    transform.localScale = new Vector3(-1, 1, 1);

                } else {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                   anim.SetBool("walk", true);
                   rb.velocity = new Vector2(XVector * speed, -gravity);
                
            } else {
                anim.SetBool("walk", false);
            }

        } else {
            
            if (!isDead) {
            
                anim.Play("enemyDeathAnimation");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;

                gManager.instance.score += 10;
            
            } else {
                transform.Rotate(new Vector3(0,0,5));
                
                if(deathTimer > 3.0f) {
                    Destroy(this.gameObject);
                } else {
                    deathTimer += deathTimer;
                }
            
            }
        }

        

    }
}
