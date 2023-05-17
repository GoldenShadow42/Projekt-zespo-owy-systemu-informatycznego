using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Referencja do obiektu, za którym ma pod¹¿aæ kamera
    public float smoothSpeed = 0.125f;  // G³adkie przemieszczanie siê kamery
    public Vector3 offset;  // Przesuniêcie kamery wzglêdem celu

    private void LateUpdate()
    {
        // Oblicz docelow¹ pozycjê kamery
        Vector3 desiredPosition = target.position + offset;

        // G³adkie przemieszczanie kamer¹
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Skieruj kamerê na cel
        transform.LookAt(target);
    }

    private void Update()
    {
        // Aktualizuj pozycjê kamery po ka¿dej klatce
        transform.position = target.position + offset;
    }
}