using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField]
    GameObject UIPanel;

    void OnMouseDown() {
        if (gameObject.name == "LeftButton")
        {
            UIPanel.GetComponent<ExampleTextPanel>().onClickLeft();
        }

        if (gameObject.name == "RightButton")
        {
            UIPanel.GetComponent<ExampleTextPanel>().onClickRight();
        }
    }
}
