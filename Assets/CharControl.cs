using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharControl : MonoBehaviour
{
    public float speed = 6f;
    public float gravityForce = 20f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Stick to the ground
        StickToGround();

        // Apply gravity
        velocity.y += Physics.gravity.y * gravityForce * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void StickToGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f, groundMask))
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f; // Small downward force to stay grounded
            }
        }
    }
}
