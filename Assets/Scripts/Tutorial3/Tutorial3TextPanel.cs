using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial3TextPanel : MonoBehaviour
{
    private string[] text;

    private string finish = "Great job! You correctly used the bucket of water to extinguish the fire. Remember, a CO2 extinguisher would not be effective for this type of fire.";

    private int curr;

    private GameObject textField;

    public GameObject leftButton;

    private float _nextTime;

    // Start is called before the first frame update
    void Start()
    {
        textField = gameObject.transform.Find("Text").gameObject;
        curr = 0;
        text = new string[5];
        text[0] = "Welcome again to FireDay: Home Fire Safety Training. In this tutorial, we will learn about the different types of fire extinguishers and their appropriate uses. Knowing which extinguisher to use can make a crucial difference in an emergency.";
        text[1] = "Water extinguishers are effective against ordinary combustible materials like paper, cloth, wood, plastics, and rubber. However, they should not be used on oil fires or electrical fires.";
        text[2] = "CO2 extinguishers are suitable for flammable liquids and electrical equipment. They are less effective in open areas due to wind dispersing the CO2.";
        text[3] = "Dry chemical powder extinguishers are versatile and can be used on ordinary combustibles, flammable liquids, and electrical fires";
        text[4] = "Now, let's put this knowledge to the test. You are in a bedroom, and a fire starts in a paper-filled dustbin. You have two options: a bucket of water and a CO2 fire extinguisher.";


        //Default text
        textField.GetComponent<TextMeshProUGUI>().SetText(text[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
        //textField.GetComponent<TextMeshProUGUI>().SetText("A");
    }

    public void onClickLeft() 
    {
        if (Time.time >= _nextTime && curr > 0)
        {
            textField.GetComponent<TextMeshProUGUI>().SetText(text[curr-1]);
            curr = curr - 1;

            _nextTime = Time.time + 0.5f;
        }
    }

    public void onClickRight()
    {
        if (Time.time >= _nextTime) {
            print(curr);
            if (curr < text.Length - 1) {
                textField.GetComponent<TextMeshProUGUI>().SetText(text[curr + 1]);
                curr = curr + 1;
            } else if (curr == text.Length - 1) {
                //BLANK
                this.gameObject.SetActive(false);
                curr = curr + 1;
            }else if (curr == text.Length) {

            }

            _nextTime = Time.time + 0.5f;
        }
    }

    public void finishText() {
        textField.GetComponent<TextMeshProUGUI>().SetText(finish);
        leftButton.SetActive(false);
    }
}
