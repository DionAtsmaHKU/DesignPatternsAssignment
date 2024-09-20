using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Rigidbody2D rb;
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Movement()
    {
        Vector2 movement;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.velocity = movement * speed;
    }

    // Handles the aiming with the mouse
    public float FindAngle()
    {
        // Aiming the weapon at the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x);
        return angle;
    }

    // Shoots a regular bullet
    void Shoot()
    {
        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab,
            transform.position, transform.rotation);

        // Set bullet angle to FindAngle();
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.angle = FindAngle();
    }
}
