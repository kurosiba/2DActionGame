using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollisionCheck : MonoBehaviour
{
    [HideInInspector] public bool isOn = false;

    private string groundTag = "Ground";
    private string enemyTag = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision) {//ここな気がする
        if(collision.tag == groundTag || collision.tag == enemyTag) {
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == groundTag || collision.tag == enemyTag) {
            isOn = false;
        }
    }

}
