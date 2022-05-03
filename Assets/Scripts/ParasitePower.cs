using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasitePower : MonoBehaviour
{
    public GameObject item;
    private int activeMode = 0;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F) && activeMode == 0)
        {
            activeMode = 1;
            Debug.Log("Mode Changed 1");
        }
        else if(Input.GetKeyDown(KeyCode.F) && activeMode == 1)
        {
            activeMode = 0;
            Debug.Log("Mode Changed 0");
        }

        if (Input.GetKeyDown(KeyCode.R) && activeMode == 0)
        {
            item.SetActive(true);
        }

        // Add in break mode

        else if(Input.GetKeyDown(KeyCode.R) && activeMode ==1)
        {
            Destroy(item);
        }
    }
}
