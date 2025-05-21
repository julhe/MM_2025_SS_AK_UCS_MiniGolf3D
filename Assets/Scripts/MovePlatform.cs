using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public bool MovePlatformToGoal;
    public float Speed;
    public Vector3 GoalPosition;
    Vector3 StartPosition;
    void Start()
    {
        StartPosition = transform.position;
    }

    public void SetPlatformActive(bool active)
    {
        MovePlatformToGoal = active;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 goalPosition = StartPosition + GoalPosition;
        if(MovePlatformToGoal)
        {
            transform.position = Vector3.MoveTowards(currentPosition, goalPosition, Speed * Time.deltaTime);
        } else
        {
            transform.position = Vector3.MoveTowards(currentPosition, StartPosition, Speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + GoalPosition);
    }
}
