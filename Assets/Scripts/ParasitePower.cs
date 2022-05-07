using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasitePower : MonoBehaviour
{
    public GameObject Room1;
    public GameObject Room2;
    private GameObject currentRoom = null;
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
        }
        else if(Input.GetKeyDown(KeyCode.F) && activeMode == 1)
        {
            activeMode = 0;
            Hammer.SetActive(false);
            Tracker.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R) && activeMode == 0)
        {
            if(currentRoom != null)
            {
                currentRoom.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentRoom = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        currentRoom = null;
    }
}
