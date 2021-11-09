using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Story : MonoBehaviour
{

    [SerializeField] Text MessageText;
    [SerializeField] GameObject StoryPanel;
    

    private int clickNum = 0;

    private void Start()
    {
            MessageText.text = "";
    }

    public void ButtonClick()
    {
        clickNum += 1;
        
        if (clickNum == 0)
        {
            MessageText.text = "";
        }else if (clickNum == 1)
        {
            MessageText.text = "これから大学生活を始めようとしてるあなた。";
        }else if(clickNum == 2)
        {
            MessageText.text = "これから大学生活を始めようとしてるあなた。" + "\n" + "\n" + "そう、そこのあなたです。";
        }else if(clickNum == 3)
        {
            MessageText.text = "大学開始から就活の準備なんて早いと思っていませんか？";
        }
        else if (clickNum == 4)
        {
            MessageText.text = "大学開始から就活の準備なんて早いと思っていませんか？" + "\n" + "\n" + "思ってますよね。";
        }
        else if (clickNum == 5)
        {
            MessageText.text = "そんなことないんですけどね。";
        }
        else if (clickNum == 6)
        {
            MessageText.text = "そんなことないんですけどね。" + "\n" + "\n" + "まあ、ゲームですから、" + "\n" + "とりあえず始めましょう。";
        }
        else if (clickNum == 7)
        {
            MessageText.text = "就活の第一歩として、";
        }
        else if (clickNum == 8)
        {
            MessageText.text = "就活の第一歩として、" + "\n" + "\n" + "怠けてる自分を倒し、" + "\n" + "ゴールを目指すのです！";
        }
        else{
            
            StoryPanel.SetActive(false);
            
            clickNum = 0;
        }
    }

    public void ButtonClick2()
    {
        clickNum += 1;       

        if (clickNum == 0)
        {
            MessageText.text = "";
        }
        else if (clickNum == 1)
        {
            MessageText.text ="大学の3年間はどうでしたか？";
        }
        else if (clickNum == 2)
        {
            MessageText.text ="大学の3年間はどうでしたか？" +  "\n" +  "実際あれくらいの速度で、" ;
        }
        else if (clickNum == 3)
        {
            MessageText.text = "大学の3年間はどうでしたか？" + "\n" + "実際あれくらいの速度で、" + "\n" + "大学生活は過ぎるのです。";
        }
        else if (clickNum == 4)
        {
            MessageText.text = "それでは、" ;
        }
        else if (clickNum == 5)
        {
            MessageText.text = "それでは、" + "\n" + "あとは面接を受けるだけですね";
        }
        else if (clickNum == 6)
        {
            MessageText.text ="最後までゴール目指して、";
        }
        else if (clickNum == 7)
        {
            MessageText.text = "最後までゴール目指して、" + "\n" + "頑張ってください！";
        }
        else
        {

            StoryPanel.SetActive(false);

            clickNum = 0;
        }
    }

}
