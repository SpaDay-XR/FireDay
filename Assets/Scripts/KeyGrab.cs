using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyGrab : MonoBehaviour
{
    public XRGrabInteractable reelDoor;

    void Start()
    {
        reelDoor.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Hand")) {
            reelDoor.enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
