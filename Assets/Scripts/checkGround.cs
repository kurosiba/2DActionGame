using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    private string groundTag = "Ground";//tagの判別
    private bool isGround = false;//設置判定
    private bool isGroundEnter, isGroundStay, isGroundExit;//emptyObjectのenter,stay,exitの判定

    public bool IsGround() {//設置判定のメソッド（頭の判定にも使用）
        if (isGroundEnter || isGroundStay) {
            isGround = true;
        }

        if (isGroundExit) {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == groundTag) {//tagの取得と判定
            isGroundEnter = true;
                }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == groundTag) {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == groundTag) {
            isGroundExit = true;
        }
    }

}
