using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private GameObject raycastedObj;

    [SerializeField] private int rayRange = 10;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private GameObject NormalSprite;
    [SerializeField] private GameObject EvidenceSprite;
    [SerializeField] private GameObject NPCSprite;
    [SerializeField] private GameObject BreakableSprite;
    [SerializeField] private GameObject Hammer;

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }

    void CastRay()
    {
        RaycastHit hitInfo = new RaycastHit();
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hitInfo, rayRange, layerMaskInteract.value))
        { 
            if (hitInfo.collider.CompareTag("Evidence"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairEvidence();
                if (Input.GetKeyDown("e"))
                {
                    hitInfo.transform.gameObject.GetComponent<Evidence>().Collect();
                }
            }
            else if (hitInfo.collider.CompareTag("NPC"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairNPC();
                //if (Input.GetKeyDown("e"))
                //{
                //    Debug.Log("I HAVE INTERACTED WITH A NPC");
                //}
            }
            else if (hitInfo.collider.CompareTag("Breakable") && Hammer.activeInHierarchy)
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairBreak();
                if (Input.GetKeyDown("e"))
                {
                    raycastedObj.AddComponent<TriangleExplosion>();
                    StartCoroutine(raycastedObj.GetComponent<TriangleExplosion>().SplitMesh(true));
                }
            }
            else 
            {
                CrosshairNormal();
            }
        }
        else
        {
            CrosshairNormal();
        }
    }
    void CrosshairEvidence()
    {
        EvidenceSprite.SetActive(true);
        NPCSprite.SetActive(false);
        NormalSprite.SetActive(false);
        BreakableSprite.SetActive(false);
    }
    void CrosshairNPC()
    {
        NPCSprite.SetActive(true);
        NormalSprite.SetActive(false);
        EvidenceSprite.SetActive(false);
        BreakableSprite.SetActive(false);
    }
    void CrosshairNormal()
    {
        NormalSprite.SetActive(true);
        EvidenceSprite.SetActive(false);
        NPCSprite.SetActive(false);
        BreakableSprite.SetActive(false);
    }

    void CrosshairBreak()
    {
        BreakableSprite.SetActive(true);
        NormalSprite.SetActive(false);
        EvidenceSprite.SetActive(false);
        NPCSprite.SetActive(false);
    }
}
