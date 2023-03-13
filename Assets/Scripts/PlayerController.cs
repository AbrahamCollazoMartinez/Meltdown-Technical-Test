using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables for movement and jump speed
    public float movementSpeed = 5f;
    public float jumpSpeed = 10f;

    // Reference to the Rigidbody component
    private Rigidbody rb;

    // Variable for tracking whether the player is grounded
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component on this object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical input axis values
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the player horizontally and vertically
        Vector3 movement = new Vector3(horizontalInput * movementSpeed, 0, verticalInput * movementSpeed);
        rb.MovePosition(transform.position + movement * Time.deltaTime);

        // Check if the player can jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Add upward force to the player
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Called when the player collides with another object
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
