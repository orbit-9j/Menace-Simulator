using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed; /* 5f */
    [SerializeField]
    private float rotationSpeed; /* 3500f */
    public ShitBehaviour shitPrefab;

    public Transform SpawnPoint1;
    public bool spawn1 = false;
    public Transform SpawnPoint2;
    public bool spawn2 = false;

    public Transform LaunchOffset;
    public int killCount;

    public TextMeshProUGUI text;
    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
 
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        float inputMagnitude = Mathf.Clamp01(movement.magnitude);
        movement.Normalize();
        transform.Translate(movement * speed * inputMagnitude * Time.deltaTime, Space.World);
        if (movement != Vector2.zero){
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shitPrefab, LaunchOffset.position, LaunchOffset.transform.rotation);
        }

        if(spawn1)
        {
            SpawnPoint1.Find("OtherCrow").transform.rotation = transform.rotation;
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(shitPrefab, SpawnPoint1.position, LaunchOffset.transform.rotation);
            }
        }
    }

    public void IncreaseKillCount()
    {
        killCount++;
        text.GetComponent<TextMeshProUGUI>().text = "Kill Count: "+killCount.ToString();
    }
}
