using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerMovement>().IncreaseKillCount();
        Destroy(gameObject);
    }
}
