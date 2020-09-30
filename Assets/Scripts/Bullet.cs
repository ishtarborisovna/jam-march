using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0F;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }


    private void Start()
    {
        Destroy(gameObject, 3F);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "covid")
        {
            Mouse.coronaKillNumber++;
            Destroy(collider.gameObject);
            Debug.Log("Covid " + Mouse.coronaKillNumber);

        }
    }
}
