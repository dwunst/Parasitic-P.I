using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject evidenceBook;
    private bool evidenceOpen = false;
    public float ScoreMultiplier = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            if (evidenceOpen)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                hud.SetActive(true);
                evidenceBook.SetActive(false);
                evidenceOpen = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                hud.SetActive(false);
                evidenceBook.SetActive(true);
                evidenceOpen = true;
                
            }
        }
    }
}
