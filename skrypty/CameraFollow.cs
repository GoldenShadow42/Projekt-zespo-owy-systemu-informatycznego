using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Referencja do obiektu, za kt�rym ma pod��a� kamera
    public float smoothSpeed = 0.125f;  // G�adkie przemieszczanie si� kamery
    public Vector3 offset;  // Przesuni�cie kamery wzgl�dem celu

    private void LateUpdate()
    {
        // Oblicz docelow� pozycj� kamery
        Vector3 desiredPosition = target.position + offset;

        // G�adkie przemieszczanie kamer�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Skieruj kamer� na cel
        transform.LookAt(target);
    }

    private void Update()
    {
        // Aktualizuj pozycj� kamery po ka�dej klatce
        transform.position = target.position + offset;
    }
}