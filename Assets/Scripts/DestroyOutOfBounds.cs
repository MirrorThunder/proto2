using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound;
    private float lowerBound;

    void Start()
    {
        // Busca el objeto Ground en la escena
        GameObject ground = GameObject.Find("Ground");

        // Obtiene el Collider del Ground
        Collider groundCollider = ground.GetComponent<Collider>();

        // Obtiene los limites del Ground
        topBound = groundCollider.bounds.max.z;
        lowerBound = groundCollider.bounds.min.z;
    }

    void Update()
    {
        // Elimina objetos que dejan el area visible del juego.
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}