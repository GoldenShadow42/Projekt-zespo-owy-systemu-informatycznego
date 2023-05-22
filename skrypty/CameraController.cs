using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 1.0f; // Czu�o�� ruchu myszki
    public Transform target; // Obiekt, na kt�rym skupia si� kamera
    public float distance = 10.0f; // Odleg�o�� kamery od obiektu
    public float minDistance = 2.0f; // Minimalna odleg�o�� kamery od obiektu
    public float maxDistance = 20.0f; // Maksymalna odleg�o�� kamery od obiektu
    public float scrollSpeed = 5.0f; // Szybko�� zmiany odleg�o�ci kamery

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Start()
    {
        // Ukryj kursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void LateUpdate()
    {
        // Ustawienie pocz�tkowej rotacji kamery na aktualn� rotacj� obiektu target
        Vector3 angles = transform.eulerAngles;
        rotationX = angles.y;
        rotationY = angles.x;
        
        // Odczyt ruchu myszki
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -90.0f, 90.0f); // Ograniczenie ruchu pionowego kamery

        // Obliczenie rotacji kamery
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0.0f);

        // Zmiana odleg�o�ci kamery za pomoc� scrolla myszki
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        distance -= scrollInput * scrollSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Obliczenie pozycji kamery
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

        // Aktualizacja pozycji i rotacji kamery
        transform.rotation = rotation;
        transform.position = position;
    }
}