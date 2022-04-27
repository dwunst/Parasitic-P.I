using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighScore;
using TMPro;

public class PlayerHS : MonoBehaviour
{
    public TMP_InputField inputGameName;
    public TMP_InputField inputPlayerName;
    public TMP_InputField inputScore;

    // Start is called before the first frame update
    public void Start()
    {
        HS.Init(this, "Game Game");
        StartCoroutine(Something());
    }

    public IEnumerator Something()
    {
        yield return new WaitForSeconds(1);
        HS.SubmitHighScore(this, "Bob", 500);
    }

}
