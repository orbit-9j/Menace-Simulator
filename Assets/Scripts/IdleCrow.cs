using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCrow : MonoBehaviour
{
    public GameObject player;
    public Animator animator; 
    void OnTriggerEnter2D(Collider2D item)
    {
        if( item.name == "Player")
        {
            animator.SetBool("ours", true);
            if (player.GetComponent<PlayerMovement>().spawn1 == false)
            {
                gameObject.transform.parent = player.GetComponent<PlayerMovement>().SpawnPoint1;
                gameObject.transform.position = player.GetComponent<PlayerMovement>().SpawnPoint1.position;
                player.GetComponent<PlayerMovement>().spawn1 = true;
            }

        }
    }
}
