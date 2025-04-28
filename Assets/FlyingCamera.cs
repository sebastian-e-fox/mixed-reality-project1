using UnityEngine;

public class FlyingCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float sprintMultiplier = 2f;
    public float lookSpeed = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse look
        yaw += lookSpeed * Input.GetAxis("Mouse X");
        pitch -= lookSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        // Movement
        float speed = moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1f);
        Vector3 move = new Vector3(
            Input.GetAxis("Horizontal"),
            (Input.GetKey(KeyCode.Space) ? 1f : 0f) - (Input.GetKey(KeyCode.LeftControl) ? 1f : 0f),
            Input.GetAxis("Vertical")
        );
        transform.position += transform.TransformDirection(move) * speed * Time.deltaTime;
    }
}
