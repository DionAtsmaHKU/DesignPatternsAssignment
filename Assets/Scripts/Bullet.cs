using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float angle;

    private float speed = 10f;
    private Vector2 vectorAngle;

    private void Start()
    {
        // Sets angle the bullet will move at
        vectorAngle = new Vector2(Mathf.Cos(angle),  Mathf.Sin(angle)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vectorAngle * speed * Time.deltaTime);
        if (transform.position.magnitude > 50)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            ObjectPoolManager.ReturnObjectToPool(collision.gameObject);
        }
    }
}
