using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gManager : MonoBehaviour
{
    public static gManager instance = null;
    public int score = 0;
    public int preStageScore = 0;
    public int stageNum = 0;
    public int continueNum = 0;

    private void Awake() {
       
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }

    }
}
