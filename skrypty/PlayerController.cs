using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 3.0f; // Prêdkoœæ poruszania siê postaci
    public float rotationSpeed = 100.0f; // Prêdkoœæ obracania postaci
    public float jumpForce = 5f; // Si³a skoku

    private bool isJumping = false; // Czy postaæ jest w trakcie skoku
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotatePlayer();
        MovePlayer();
        Jump();

        // Sprawdzenie, czy gracz spad³ poni¿ej pozycji Y -10
        if (transform.position.y < -10f)
        {
            TeleportToPosition(new Vector3(1f, 1f, 1f)); // Teleportowanie na pozycjê (1, 1, 1)
        }
    }

    // Metoda odpowiedzialna za obracanie postaci¹ w osi Y za pomoc¹ myszki
    private void RotatePlayer()
    {
        float rotationY = Input.GetAxis("Mouse X")*2.0f;
        transform.Rotate(0.0f, rotationY, 0.0f);
    }

    // Metoda odpowiedzialna za poruszanie postaci¹ na boki, do przodu i do ty³u
    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float moveForward = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = new Vector3(moveHorizontal, 0f, moveForward);
        }
        else
        {
            movement = new Vector3(moveHorizontal, 0f, moveForward);
        }

        transform.Translate(movement);
    }

    // Metoda odpowiedzialna za skakanie postaci
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    // Metoda wywo³ywana po kolizji postaci z innym obiektem
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false; // Zatrzymanie skoku po zetkniêciu z pod³o¿em
        }
    }

    // Metoda teleportuj¹ca gracza na okreœlon¹ pozycjê
    private void TeleportToPosition(Vector3 position)
    {
        transform.position = position;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
