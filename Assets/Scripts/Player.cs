using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
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

    // Shoots a bullet
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
