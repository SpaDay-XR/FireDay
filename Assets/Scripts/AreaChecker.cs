using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChecker : MonoBehaviour
{
    public bool exited = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("MainCamera")) {
            exited = true;
        }
    }
}
