using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Weapon
{
    private Rigidbody2D playerRb;

    public Weapon(Rigidbody2D rb)
    {
        playerRb = rb;
    }

    void WeaponUpdate()
    {
        
    }

    // Handles the aiming with the mouse
    public float FindAngle()
    {
        // Aiming the weapon at the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) *
                                  Mathf.Rad2Deg - 180;
        return angle;
    }
}
