using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnterrichtGoal : MonoBehaviour
{
    public string NextSceneName = string.Empty;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnterrichtBallScript>())
        {
            
            print("Yippe Jaaa Juhuu.");

            GameSceneManager.instance.SwitchScene(NextSceneName);
        }
    }
}
