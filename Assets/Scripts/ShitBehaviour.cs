using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitBehaviour : MonoBehaviour
{

    public float speed = 3f;
    public Sprite splat;

    public GameObject splatObject;

    private Collision2D collision;

    void Update()
    {
     transform.position += -transform.right * Time.deltaTime * speed; 
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        collision = coll;
        splatObject.GetComponent<SpriteRenderer>().sprite = splat;
        Invoke("DestroyObject", 5);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
