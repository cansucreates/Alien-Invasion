using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the object
    private Rigidbody enemyRb; 
    private float zDestroy = -12f; // Position to destroy the object
   
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(Vector3.forward * -speed);

        if (transform. position.z < zDestroy) {
            Destroy(gameObject);
        }
        
    }
}
