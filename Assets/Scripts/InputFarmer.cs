using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction jumpAction;

    public float speed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    private void FixedUpdate()
    {
        // Leer las teclas de movimiento
        Vector2 input = moveAction.ReadValue<Vector2>();

        // Convertir el movimiento 2D a 3D
        Vector3 movimiento = new Vector3(input.x, 0f, input.y);

        // Mover al jugador usando el Rigidbody
        rb.MovePosition(
            rb.position + movimiento * speed * Time.fixedDeltaTime
        );
    }

    private void Update()
    {
        // Si presionamos espacio, saltamos
        if (jumpAction.WasPressedThisFrame())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
