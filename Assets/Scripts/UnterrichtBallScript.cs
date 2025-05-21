using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnterrichtBallScript : MonoBehaviour
{
    public ForceMode forceMode;

    public int hits;
    Vector3 dragStart;

    Vector3 startPosition;

    private void Start()
    {
        // Aufgabe 1.1.: Legt eine Variable "StartPosition" vom Typ "Vector3" in dieser Klasse an.

        // Aufgabe 1.2.: Speichert beim Starten die Position des Balles in "StartPositon".
        startPosition = transform.position;

        // Aufgabe 1.3.: Statt 'print("HILFE ICH FALLE!")' soll die position des Rigidbodys auf "StartPosition" gestzt werden.
    }
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        
        if (GetComponent<Rigidbody>().IsSleeping())
        {
            if (Input.GetMouseButton(0))
            {
                // Wenn: erstes mal das mouse button down -> dragStart setzen.
                if(Input.GetMouseButtonDown(0))
                {
                    dragStart = hit.point;
                }
                Debug.DrawLine(dragStart, hit.point, Color.red);
            }

            // Wenn: mouse button up -> dann kraft auf ball.
            if (Input.GetMouseButtonUp(0))
            {
                GetComponent<Rigidbody>().AddForce(dragStart - hit.point, forceMode);

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