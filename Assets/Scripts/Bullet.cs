using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    public float angle;
    private Vector2 vectorAngle;

    private void Start()
    {
        vectorAngle = new Vector2(Mathf.Cos(angle),  Mathf.Sin(angle)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vectorAngle * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            // Send enemy to object pool
        }
        else
        {
            // Send bullet to object pool
        }
    }
}
