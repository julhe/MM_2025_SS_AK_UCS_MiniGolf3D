using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(LineRenderer), typeof(Rigidbody))]
public class UnterrichtBallScript : MonoBehaviour
{
    public ForceMode forceMode;
    public float ForceMult = 1.0f;
    int hits;

    Vector3 startPosition;

    private void Start()
    {
        // Aufgabe 1.1.: Legt eine Variable "StartPosition" vom Typ "Vector3" in dieser Klasse an.

        // Aufgabe 1.2.: Speichert beim Starten die Position des Balles in "StartPositon".
        startPosition = transform.position;

        // Aufgabe 1.3.: Statt 'print("HILFE ICH FALLE!")' soll die position des Rigidbodys auf "StartPosition" gestzt werden.
        GetComponent<LineRenderer>().enabled = false;
    }
    void Update()
    {
       // RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane planeAroundBall = new Plane(Vector3.up, transform.position);

        float raycastOut = 0.0f;
        planeAroundBall.Raycast(ray, out raycastOut);
        Vector3 hitPoint = raycastOut * ray.direction + ray.origin;
        LineRenderer lineRenderer = GetComponent<LineRenderer>();



        // Ziel: wenn wir die maus ziehen soll der line renderer sichbar sein, ansonsten nicht.
        if (GetComponent<Rigidbody>().IsSleeping())
        {
            if (Input.GetMouseButton(0))
            {

                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hitPoint);
                //Debug.DrawLine(dragStart, hit.point, Color.red);
            }

            // Wenn: mouse button up -> dann kraft auf ball.
            if (Input.GetMouseButtonUp(0))
            {
                lineRenderer.enabled = false;

                GetComponent<Rigidbody>().AddForce((transform.position - hitPoint) * ForceMult, forceMode);

                // Erhöhe hits um 1.
                hits += 1;

                // Finde ein Component/Object vom Typen UiManager und rufe die SetScore Methode mit 'hits' als Parameter auf.
                FindObjectOfType<UiManager>().SetScore(hits);
            }
        } 
    }

    private void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody.position.y < -10.0f)
        {
            print("HILFE ICH FALLE!");
            rigidbody.position = startPosition;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

    }

}