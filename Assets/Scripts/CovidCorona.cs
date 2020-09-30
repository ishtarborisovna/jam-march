using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidCorona : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 delta;
    public float speed = 10f;

    private void Start()
    {
        mousePos = GameObject.Find("Mouse").transform.position;
        delta = mousePos - transform.position;
        delta.Normalize();
        Destroy(gameObject, 5F);
    }
    private void Update()
    {
        transform.position = transform.position + (delta * speed * Time.deltaTime);
    }
}
