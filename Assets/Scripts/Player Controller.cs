using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //variable creation
    private Rigidbody rb;
    private Vector3 movement;
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (CompareTag("Player"))
        {
            //horizontal movement
            movement.x = Input.GetAxis("Horizontal");

            //"Verticle" movement
            movement.z = Input.GetAxis("Vertical");

            rb.AddForce(movement.normalized * speed);
        }
    }
}
