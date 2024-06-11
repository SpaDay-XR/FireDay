using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHose : MonoBehaviour
{
    public GameObject hoseValve;
    public GameObject nozzleValve;
    public AreaChecker areaChecker;
    public bool completedHoseCheck = false;
    public bool completedNozzleCheck = false;
    public bool completedTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hoseValve.transform.localRotation.y < -0.9 && !completedHoseCheck) {
            completedHoseCheck = true;
        }

        if (nozzleValve.transform.localRotation.z < -0.9 && !completedNozzleCheck && completedHoseCheck) {
            completedNozzleCheck = true;
        }

        if (areaChecker.exited && !completedTutorial) {
            print(completedHoseCheck && completedNozzleCheck);
            completedTutorial = true;
        }
    }
}
