using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPath : MonoBehaviour
{
   
    public Vector3 offset;
  
    int startRotation;
    public Transform[] target;
    public GameObject player;
    public float speed;
    private int current;
    
    void Update()
    {

        if (transform.position != target[current].position)
        {

            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed);

            GetComponent<Rigidbody>().MovePosition(pos);

        }
        else if(Input.GetKeyDown("e"))
        {
            GetComponent<Rigidbody>().MovePosition(this.player.position);
        }
        else current = (current + 1) % target.Length;

        
    }
 

}
