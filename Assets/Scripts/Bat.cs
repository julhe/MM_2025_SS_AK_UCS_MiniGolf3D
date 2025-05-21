using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public Rigidbody ball;
    public ForceMode forceMode;

    Vector3 dragStart, dragEnd;
    bool startSet;

    public TextMeshProUGUI uiShotCount;
    public int shotCount;
    // Update is called once per frame
    void Update()
    {
        if (ball.IsSleeping())
        {
            uiShotCount.color = Color.green;
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    if (!startSet)
                    {
                        dragStart = hit.point;
                        startSet = true;
                    }
                    else
                    {
                        dragEnd = hit.point;
                    }
                }

                Debug.DrawLine(dragStart, dragEnd);

            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    ball.AddForce(dragStart - dragEnd, forceMode);
                    shotCount++;
                    uiShotCount.text = shotCount.ToString();
                }
                startSet = false;
                dragStart = dragEnd = Vector3.zero;
            }
        } else
        {
            uiShotCount.color = Color.grey;
        }
        
    }
}
