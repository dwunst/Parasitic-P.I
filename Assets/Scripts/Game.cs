using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject evidenceBook;
    private bool evidenceOpen = false;
    public float ScoreMultiplier = 1.0f;

    //Timer Variables
    private int Seconds = 0;
    private int Minutes = 0;
    private bool GameRunning = true;
    public TextMeshProUGUI time;

    private void Start()
    {
        StartCoroutine(Time());
    }


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

    private IEnumerator Time()
    {
        while (GameRunning)
        {
            Seconds += 1;
            if (Seconds == 60)
            {
                Seconds = 0;
                Minutes += 1;
            }
            time.text = string.Format("{0}:{1}", Minutes.ToString(), Seconds.ToString("00"));
            yield return new WaitForSeconds(1);
        }
    }
}
