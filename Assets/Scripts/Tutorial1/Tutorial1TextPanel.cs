using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial1TextPanel : MonoBehaviour
{
    private string[] text;

    private string finish = "Great job! You have successfully extinguished the fire.";

    private int curr;

    private GameObject textField;

    public GameObject leftButton;

    public GameObject image;

    public ParticleSystem fire;

    public AudioSource fireAudio;
    public Camera cam;

    private float _nextTime;

    // Start is called before the first frame update
    void Start()
    {
        fire.Stop();

        image = gameObject.transform.Find("Image").gameObject;
        image.SetActive(false);

        textField = gameObject.transform.Find("Text").gameObject;
        curr = 0;
        text = new string[11];
        text[0] = "Welcome to FireDay: Home Fire Safety Training. In this tutorial, we will learn about the different types of fire extinguishers and how to use them effectively. Remember, being prepared can save lives.";
        text[1] = "Water extinguishers are effective against ordinary combustible materials like paper, cloth, wood, plastics, and rubber. However, they should not be used on oil fires or electrical fires.";
        text[2] = "CO2 extinguishers are suitable for flammable liquids and electrical equipment. They are less effective in open areas due to wind dispersing the CO2.";
        text[3] = "Dry chemical powder extinguishers are versatile and can be used on ordinary combustibles, flammable liquids, and electrical fires.";
        text[4] = "Squeeze the lever to release the extinguishing agent.";
        text[5] = "Next, let's understand the basics of using a fire extinguisher with the P.A.S.S. method: Pull, Aim, Squeeze, Sweep";
        text[6] = "Pull out the safety pin as instructed on the label.";
        text[7] = "Aim the nozzle at the base of the fire.";
        text[8] = "Squeeze the lever to release the extinguishing agent.";
        text[9] = "Sweep the nozzle from side to side to cover the area of the fire.";
        text[10] = "Now, let's put what we've learned into practice. You are in a bedroom, and a fire starts in a paper-filled dustbin.";
        
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
                fire.Play();
                fireAudio.Play();

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
