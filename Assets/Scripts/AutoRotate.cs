using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: rotiert ein Objekt über Zeit.
[RequireComponent(typeof(Rigidbody))]
public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationSpeed;
    private void FixedUpdate()
    {
        // Schnappe den Rigidbody.
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        // Schnappe die Rotation des Rigidbodies.
        Quaternion rotation = rigidbody.rotation;
        // Rotiere die Rotation um unsere Geschwindigkeit.
        rotation *= Quaternion.Euler(rotationSpeed * Time.fixedDeltaTime);
       
        // Setze die neue Rotation auf unseren Rigidbody.
        rigidbody.rotation = rotation;
        
    }
}
