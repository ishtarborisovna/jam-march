using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covid : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 delta;
    public float speed = 2f;

    private void Start()
    {
        mousePos = GameObject.Find("Mouse").transform.position;
        delta = mousePos - transform.position;
        delta.Normalize();
    }
    private void Update()
    {
        transform.position = transform.position + (delta * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            mousePos = GameObject.Find("Mouse").transform.position;
            delta = mousePos - transform.position;
            delta.Normalize();
        }
    }
}
