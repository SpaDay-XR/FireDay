using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial6TextPanel : MonoBehaviour
{
    private string[] text;
    private string finish = "Great job! By following these steps, you've effectively increased your chances of survival in a fire. Remember these steps as they could be life-saving in an actual emergency.";

    private int curr;

    private GameObject textField;

    public GameObject leftButton;

    public GameObject image;

    public Camera cam;

    private float _nextTime;

    // Start is called before the first frame update
    void Start()
    {
        _nextTime = Time.time + 0.5f;

        image = gameObject.transform.Find("Image").gameObject;
        image.SetActive(false);

        textField = gameObject.transform.Find("Text").gameObject;
        curr = 0;
        text = new string[6];
        text[0] = "Welcome again to FireDay: Emergency Response Training. In this tutorial, we will learn about the correct actions to take when trapped in a fire. It is vital to know these steps as they can significantly reduce injury in such situations.";
        text[1] = "Enter a safe room. Preferably one which has open windows, good ventilation and overlooks a road.";
        text[2] = "Shut the door behind you and seal the gap beneath the door with a blanket, rug or other fabric to prevent smoke from entering the room.";
        text[3] = "Go to the window, shout for help to alert others of the fire and dial 995 for the SCDF if you are able to.";
        text[4] = "Stay calm and do not attempt to jump out of the building.";
        text[5] = "Now, let's put this knowledge to the test. You are in your living room when suddenly a big fire breaks out.";

        /*
        text[6] = "Great job! By following these steps, you've effectively increased your chances of survival in a fire. Remember these steps as they could be life-saving in an actual emergency.";
        */

        //Default text
        textField.GetComponent<TextMeshProUGUI>().SetText(text[0]);
        transform.position = new Vector3 (transform.position.x, cam.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform);
        transform.position = Vector3.Lerp(transform.position, new Vector3 (transform.position.x, cam.transform.position.y, transform.position.z), 0.2f);
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
                textField.SetActive(false);
                image.SetActive(true);
                curr = curr + 1;
            } else if (curr == text.Length) {
                textField.SetActive(true);
                image.SetActive(false);   
                this.gameObject.SetActive(false);
                curr = curr + 1;
            } else if (curr == text.Length + 1) {
                SceneManager.LoadScene(0);
            }

            _nextTime = Time.time + 0.5f;
        }
    }

    public void finishText() {
        textField.GetComponent<TextMeshProUGUI>().SetText(finish);
        leftButton.SetActive(false);
    }
}
