using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50.0f;
    private Vector2 xLimits = new Vector2(-13f, 13f);
    private Vector2 zLimits = new Vector2(-1f, 12f);
    private Vector3 moveDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    void FixedUpdate()
    {
        Vector3 newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, xLimits.x, xLimits.y);
        newPosition.z = Mathf.Clamp(newPosition.z, zLimits.x, zLimits.y);
        rb.MovePosition(newPosition);

        // clear the velocity to prevent sliding
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with enemy!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
