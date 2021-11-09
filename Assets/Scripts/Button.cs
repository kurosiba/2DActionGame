using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
using UnityEngine.SceneManagement;
 public class Button : MonoBehaviour
 {
     private bool firstPush = false;
    private int clickNum = 0;

     public void GameStart()
     {
        
          if (!firstPush)
          {
             
            SceneManager.LoadScene("takenokoScenes");
              firstPush = true;
            if (gManager.instance)
            {
                gManager.instance.score = 0;
            }
        }
     }

    public void NextStarge()
    {

        if (!firstPush)
        {

            SceneManager.LoadScene("1-2Scene");
            firstPush = true;
            
        }
    }

    public void GameReTry()
    {

        if (!firstPush)
        {
            if (gManager.instance.stageNum == 0)
            {
                gManager.instance.score = gManager.instance.preStageScore;
                SceneManager.LoadScene("takenokoScenes");
                firstPush = true;
            }else if(gManager.instance.stageNum == 1)
            {
                gManager.instance.score = gManager.instance.preStageScore;
                SceneManager.LoadScene("1-2Scene");
                firstPush = true;
            }else
            {
                Debug.Log("retry error");
            }
        }
    }

    public void GoStory()
    {
        
        if (!firstPush)
        {

            SceneManager.LoadScene("StoryScene");
            firstPush = true;

            
        }
    }

    public void GoTitle()
    {
        if (!firstPush)
        {

            SceneManager.LoadScene("titleScene");
            firstPush = true;
            gManager.instance.stageNum = 0;
            gManager.instance.score = 0;
            gManager.instance.preStageScore = 0;

        }
    }

    public void StoryProgress()
    {
       
        clickNum += 1;

        if(clickNum == 3)
        {

            clickNum = 0;
        }
    }
}
