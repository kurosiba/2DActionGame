using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story2 : MonoBehaviour
{
    [SerializeField] Text MessageText;
    [SerializeField] GameObject StoryPanel;


    private int clickNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        MessageText.text = "a";
    }

    public void ButtonClick2()
    {
        clickNum += 1;
        Debug.Log(clickNum);

        if (clickNum == 0)
        {
            MessageText.text = "";
        }
        else if (clickNum == 1)
        {
            MessageText.text = "2ストーリー中";
        }
        else if (clickNum == 2)
        {
            MessageText.text = "2ストーリー終了";
        }
        else
        {

            StoryPanel.SetActive(false);

            clickNum = 0;
        }
    }
}
