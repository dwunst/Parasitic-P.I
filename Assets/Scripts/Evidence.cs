using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Evidence : MonoBehaviour
{
    [SerializeField] private GameObject bookEvidence;
    [SerializeField] private float Score;
    [SerializeField] private TextMeshProUGUI score;
    public void Collect()
    {
        if (Score != 0)
        {
            score.text = (int.Parse(score.text) + Score).ToString();
        }
        else
        {
            Debug.Log("This isn't evidence");
        }
        this.gameObject.SetActive(false);
        bookEvidence.SetActive(true);
    }
}
