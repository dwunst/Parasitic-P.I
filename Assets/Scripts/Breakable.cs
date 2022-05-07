using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject Player;
    public GameObject originalObject;
    public GameObject fractureObject;
    public float impactMinForce = 5;
    public float impactMaxForce = 100;
    public float impactForceRadius = 30;
    public float fragScaleFactor = 1;

    // Start is called before the first frame update
    public void Break()
    {
        originalObject.SetActive(false);
        fractureObject.SetActive(true);
        foreach (Transform t in fractureObject.transform)
        {
            var rb = t.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 originalPos = originalObject.transform.position;
                Vector3 playerPos = Player.transform.position;
                Vector3 midpoint = playerPos + (originalPos - playerPos)/2;

                rb.AddExplosionForce(Random.Range(impactMinForce, impactMaxForce), midpoint, impactForceRadius);
            }
            StartCoroutine(Shrink(t, 2));
        }

        Destroy(fractureObject, 5);
    }

    private IEnumerator Shrink(Transform t, float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector3 newScale = t.localScale;

        while (newScale.x >= 0)
        {
            newScale -= new Vector3(fragScaleFactor, fragScaleFactor, fragScaleFactor);

            t.localScale = newScale;
            yield return new WaitForSeconds(0.05f);
        }
    }

}
