using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public Vector2 moveInput;

    public float speed = 10.0f;

    public GameObject projectilePrefab;
    public InputAction fireAction;

    public GameObject ground;

    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    void Update()
    {
        // Lee el movimiento
        moveInput = moveAction.ReadValue<Vector2>();

        // Movimiento en X y Z
        Vector3 movement = new Vector3(
            moveInput.x,
            0,
            moveInput.y
        );

        // Mueve al personaje usando la velocidad
        transform.position += movement * speed * Time.deltaTime;

        // Mantiene al personaje dentro del Ground
        if (ground != null)
        {
            Collider groundCollider = ground.GetComponent<Collider>();

            if (groundCollider != null)
            {
                Bounds bounds = groundCollider.bounds;

                Vector3 position = transform.position;

                position.x = Mathf.Clamp(
                    position.x,
                    bounds.min.x,
                    bounds.max.x
                );

                position.z = Mathf.Clamp(
                    position.z,
                    bounds.min.z,
                    bounds.max.z
                );

                transform.position = position;
            }
        }

        // Disparar
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