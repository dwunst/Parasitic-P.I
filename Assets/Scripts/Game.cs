using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    //Hud Variables
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private GameObject evidenceBook;
    [SerializeField] private GameObject Report;
    private bool evidenceOpen = false;

    //Score Variables
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI finalScore;
    private float ScoreMultiplier = 1.0f;
    private float Score = 0.0f;


    //Timer Variables
    private int Seconds = 0;
    private int Minutes = 0;
    private bool GameRunning = true;
    public TextMeshProUGUI time;
    public int averageLevelTime;
    //Cause im dumb
    private float Secondsf;
    private float averageLevelTimef;

    private void Start()
    {
        StartCoroutine(Time());
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            Report.SetActive(true);
            Crosshair.SetActive(false);
            evidenceBook.SetActive(false);
            HUD.SetActive(false);
            GameOver();
        }
        if (Input.GetKeyDown("i"))
        {
            if (evidenceOpen)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Crosshair.SetActive(true);
                evidenceBook.SetActive(false);
                evidenceOpen = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Crosshair.SetActive(false);
                evidenceBook.SetActive(true);
                evidenceOpen = true;
                
            }
        }
    }

    private void GameOver()
    {
        StopAllCoroutines();
        Secondsf = Seconds + (60 * Minutes);
        averageLevelTimef = averageLevelTime;
        ScoreMultiplier = 2.0f-(Secondsf/averageLevelTimef);
        Score = float.Parse(score.text) * ScoreMultiplier;
        finalScore.text = "Final Score: " + Score.ToString();

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
            if((Seconds + (60 * Minutes)) == averageLevelTime)
            {
                GameOver();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
