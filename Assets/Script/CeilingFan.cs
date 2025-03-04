using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingFan : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    void Update()
    {
        // Gira alrededor del eje Y a la velocidad definida.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
