using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPanel : MonoBehaviour
{
    private string[] text;

    private int curr;

    private GameObject textField;

    // Start is called before the first frame update
    void Start()
    {
        textField = gameObject.transform.Find("Text").gameObject;
        curr = 0;
        text = new string[3];
        text[0] = "left";
        text[1] = "middle";
        text[2] = "right";
    }

    // Update is called once per frame
    void Update()
    {
        //textField.GetComponent<TextMeshProUGUI>().SetText("A");
    }

    public void onClickLeft() 
    {
        if (curr > 0)
        {
            textField.GetComponent<TextMeshProUGUI>().SetText(text[curr-1]);
            curr = curr - 1;
        }
        //textField.GetComponent<TextMeshProUGUI>().SetText("A");
    }

    public void onClickRight()
    {
        if (curr < text.Length - 1)
        {
            textField.GetComponent<TextMeshProUGUI>().SetText(text[curr+1]);
            curr = curr + 1;
        }
    }
}
