using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    [SerializeField] private GameObject bookEvidence;

    public void Collect()
    {
        this.gameObject.SetActive(false);
        bookEvidence.SetActive(true);
    }
}
