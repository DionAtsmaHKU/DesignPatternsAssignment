using UnityEngine;

public class Enemy : MonoBehaviour, IStateRunner
{
    [SerializeField] Rigidbody2D rb;

    public float speed { get; set; }

    private FSM fsm;

    void OnEnable()
    {
        fsm = new FSM(this);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.Execute();
        
    }

    void FixedUpdate()
    {
        // Enemy moves towards middle of the screen (where the player is)
        Vector3 movement = new Vector3(0, 0) - transform.position;
        rb.velocity = movement * speed * Time.fixedDeltaTime;
    }
}
