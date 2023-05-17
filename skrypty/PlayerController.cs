using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Szybko�� poruszania si� postaci
    public float rotateSpeed = 10f;  // Szybko�� obracania postaci

    private Rigidbody player;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Odczytaj wej�cie gracza
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Poruszanie postaci
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        player.MovePosition(transform.position + movement);

        // Obracanie postaci w kierunku ruchu
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }

    }
}
