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
        score.text = (int.Parse(score.text) + Score).ToString();
        this.gameObject.SetActive(false);
        bookEvidence.SetActive(true);
    }
}
