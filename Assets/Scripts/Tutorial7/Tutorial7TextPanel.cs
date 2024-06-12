using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial7TextPanel : MonoBehaviour
{
    private string[] text;

    private string finish = "Great job! By following these steps, you've effectively increased your chances of survival in a smoke-logged room. Remember these steps as they could be life-saving in an actual emergency.";

    private int curr;

    private GameObject textField;

    public GameObject leftButton;

    public SmokeRoomTutorial smokeRoomTutorial;

    public GameObject image;

    public Camera cam;

    private float _nextTime;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.transform.Find("Image").gameObject;
        image.SetActive(false);

        textField = gameObject.transform.Find("Text").gameObject;
        curr = 0;
        text = new string[5];
        text[0] = "Welcome again to FireDay: Emergency Response Training. In this tutorial, we will learn about the correct actions to take when trapped in a smoke-logged room. It is vital to know these steps as they can significantly reduce injury in such situations.";
        text[1] = "If you are in a smoke-logged room, remember not to panic as this can worsen the situation. Instead, follow these critical steps:";
        text[2] = "Cover your nose and mouth with a wet cloth and avoid inhaling through the mouth. This can help filter out some of the smoke and provide cleaner air for you to breathe.";
        text[3] = "Get down, keep close to the ground and crawl towards the point of escape under the smoke. Smoke rises, so the air near the floor will be clearer.";
        text[4] = "Now, let's put this knowledge to the test. You are in your bedroom when suddenly smoke starts entering the room.";

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
            if (curr < text.Length - 1) {
                textField.GetComponent<TextMeshProUGUI>().SetText(text[curr + 1]);
                curr = curr + 1;
            } else if (curr == text.Length - 1) {
                textField.SetActive(false);
                image.SetActive(true);
                curr = curr + 1;
            } else if (curr == text.Length) {
                smokeRoomTutorial.StartSmoking();

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
