using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{

    [SerializeField]private Text scoreText;
    [SerializeField]private Text messageText;
    [SerializeField] private Text endText;
    [SerializeField] private Text endTitleText;
    [SerializeField]private Image bacuground;
    [SerializeField] private GameObject StoryPanel;

    private int oldScore;
    private int clickNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText != null && gManager.instance != null)
        {
            scoreText.text = "score " + gManager.instance.score.ToString();
        }

        if(gManager.instance.score == 0)
        {        
            endTitleText.text = (" Bat   End");
            endText.text = (" Bat   End");

        }
        else if(gManager.instance.score == 120)
        {         
            endTitleText.text = (" True   End");
            endText.text = (" True   End");

        }
        else if((gManager.instance.score >= 90 && (gManager.instance.score <= 110)))
        {
            endTitleText.text = ("Normal 2 End");
            endText.text = (" Normal 2 End");

        }
        else
        {
            endTitleText.text = ("Normal 1 End");
            endText.text = (" Normal 1 End");

        }

    }

    public void ending()
    {
        clickNum += 1;

        if (scoreText != null && gManager.instance != null)
        {
            
        }

        if (gManager.instance.score == 0)
        {
            if (clickNum == 0)
            {
                messageText.text = "";
            }
            else if (clickNum == 1)
            {
                messageText.text = "面接の結果は...";
            }
            else if (clickNum == 2)
            {
                messageText.text = "面接の結果は..." + "不採用となりました。";
            }
            else if (clickNum == 3)
            {
                messageText.text = "一人も怠ける自分を倒せませんでしたね。";
            }
            else if (clickNum == 4)
            {
                messageText.text = "これからの生活を悔い改めて、";
            }
            else if (clickNum == 5)
            {
                messageText.text = "これからの生活を悔い改めて、" + "\n" + "実際の就活を頑張りましょう。";
            }
            else
            {

                StoryPanel.SetActive(false);

                clickNum = 0;
            }


        }
        else if (gManager.instance.score == 120)
        {

            if (clickNum == 0)
            {
                messageText.text = "";
            }
            else if (clickNum == 1)
            {
                messageText.text = "面接の結果は...";
            }
            else if (clickNum == 2)
            {
                messageText.text = "面接の結果は..." + "採用となりました。";
            }
            else if (clickNum == 3)
            {
                messageText.text = "全ての怠ける自分を倒しましたね。";
            }
            else if (clickNum == 4)
            {
                messageText.text = "これからの生活に気を付けて、" ;
            }
            else if (clickNum == 5)
            {
                messageText.text = "これからの生活に気を付けて、" + "\n" + "実際の就活を頑張りましょう。";
            }
            else
            {

                StoryPanel.SetActive(false);

                clickNum = 0;
            }

        }
        else if ((gManager.instance.score >= 90 && (gManager.instance.score <= 110)))
        {
            if (clickNum == 0)
            {
                messageText.text = "";
            }
            else if (clickNum == 1)
            {
                messageText.text = "面接の結果は...";
            }
            else if (clickNum == 2)
            {
                messageText.text = "面接の結果は..." + "採用となりました。";
            }
            else if (clickNum == 3)
            {
                messageText.text = "ある程度の怠ける自分を倒せましたね。";
            }
            else if (clickNum == 4)
            {
                messageText.text = "これからの生活に気を付けて、";
            }
            else if (clickNum == 5)
            {
                messageText.text = "これからの生活に気を付けて、" + "\n" + "実際の就活を頑張りましょう。";
            }
            else
            {

                StoryPanel.SetActive(false);

                clickNum = 0;
            }

        }
        else
        {
            if (clickNum == 0)
            {
                messageText.text = "";
            }
            else if (clickNum == 1)
            {
                messageText.text = "面接の結果は...";
            }
            else if (clickNum == 2)
            {
                messageText.text = "面接の結果は..." + "不採用となりました。";
            }
            else if (clickNum == 3)
            {
                messageText.text = "少ししか怠ける自分を倒せませんでしたね。";
            }
            else if (clickNum == 4)
            {
                messageText.text = "これからの生活を悔い改めて、";
            }
            else if (clickNum == 4)
            {
                messageText.text = "これからの生活を悔い改めて、" + "\n" + "実際の就活を頑張りましょう。";
            }
            else
            {

                StoryPanel.SetActive(false);

                clickNum = 0;
            }


        }
    }
  
}
