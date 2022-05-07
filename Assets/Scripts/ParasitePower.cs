using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasitePower : MonoBehaviour
{
    public GameObject Evidence;
    private int activeMode = 0;
    public GameObject Tracker;
    public GameObject Hammer;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F) && activeMode == 0)
        {
            activeMode = 1;
            Hammer.SetActive(true);
            Tracker.SetActive(false);
            Debug.Log("Mode Changed 1");
        }
        else if(Input.GetKeyDown(KeyCode.F) && activeMode == 1)
        {
            activeMode = 0;
            Hammer.SetActive(false);
            Tracker.SetActive(true);
            Debug.Log("Mode Changed 0");
        }

        if (Input.GetKeyDown(KeyCode.R) && activeMode == 0)
        {
            Evidence.SetActive(true);
        }
    }
}
