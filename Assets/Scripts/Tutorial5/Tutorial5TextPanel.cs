using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial5TextPanel : MonoBehaviour
{
    private string[] text;
    string finish = "Great job! By stopping, dropping, and rolling, you've effectively put out the fire on your clothing and prevented further injuries. Remember these steps as they could be life-saving in an actual emergency.";

    private int curr;

    private GameObject textField;

    public StopDropTutorial stopDropTutorial;

    public GameObject leftButton;

    public GameObject image;
    public Camera cam;

    private float _nextTime;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.transform.Find("Image").gameObject;
        image.SetActive(false);

        _nextTime = Time.time + 0.5f;

        textField = gameObject.transform.Find("Text").gameObject;
        curr = 0;
        text = new string[6];
        text[0] = "Welcome again to FireDay: Emergency Response Training. In this tutorial, we will learn about the correct actions to take when clothing catches fire. It is vital to know these steps as they can significantly reduce injury in such situations.";
        text[1] = "If your clothes catch fire, remember not to run or panic as this can worsen the situation by providing more oxygen to the flames. Instead, follow these critical steps:";
        text[2] = "Stop. Cease all movement immediately. Running or moving quickly can fan the flames and make the fire worse.";
        text[3] = "Drop. Carefully get down onto the ground. This prevents the flames from spreading upwards.";
        text[4] = "Roll. Perform a rolling motion on the ground until all flames are extinguished. This action smothers the fire.";
        text[5] = "Now, let's put this knowledge to the test. You are in your kitchen when suddenly your clothes catch fire due to proximity to an open flame or heat source.";

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
                stopDropTutorial.StartFire();

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
