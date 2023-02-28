using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpSpeed = 6f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

}
