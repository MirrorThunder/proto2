using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public Vector2 moveInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;
    public InputAction fireAction;

    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    void Update()
    {
        // Mantiene al Player dentro de los límites laterales.
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Lee el movimiento.
        moveInput = moveAction.ReadValue<Vector2>();

        // A/D = izquierda y derecha
        // W/S = adelante y atrás
        Vector3 movement = new Vector3(
            moveInput.x,
            0,
            moveInput.y
        );

        transform.Translate(movement * Time.deltaTime * speed);

        // Disparar.
        if (fireAction.triggered)
        {
            Instantiate(
                projectilePrefab,
                transform.position,
                projectilePrefab.transform.rotation
            );
        }
    }
}