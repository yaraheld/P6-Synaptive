using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10f; // Geschwindigkeit des Autos

    private void Update()
    {
        // Bewegung entlang der Z-Achse
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
