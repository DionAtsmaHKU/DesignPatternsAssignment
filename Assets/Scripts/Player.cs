using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {

    }

    // Aiming? Shooting?
}

/*

public class PlayerGun : MonoBehaviour
{
    private Player player;
    public PlayerGun(Player player) { this.player = player; }

    // Handles the aiming of the gun the player is holding
    private void RotateGun()
    {
        // Calculating the angle of where the player's mouse is in relation to the player
        Vector2 aimDirection = Camera.main.ScreenToWorldPoint(
            Input.mousePosition) - player.transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x);
        float angleDeg = angle * Mathf.Rad2Deg - 180;

        // Rotating the gun according to where the player is pointing their mouse
        Quaternion rotation = Quaternion.AngleAxis(angleDeg, Vector3.forward);
        transform.rotation = rotation;

        // Has the gun rotate around the player at all times
        transform.position = new Vector2(1.5f * Mathf.Cos(angle) +
            player.transform.position.x, 1.5f * Mathf.Sin(angle) +
            player.transform.position.y);
    }

// Shoots a regular bullet
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,
            bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletSpawnPoint.right * bulletSpeed, ForceMode2D.Impulse);
        cooldownTimer = cooldown;
        pewSound.Play();
    }
}

*/
