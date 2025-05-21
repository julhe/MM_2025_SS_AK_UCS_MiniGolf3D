using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    // Update is called once per frame
    //void Update()
    //{
    // //   uiText.text = GetComponent<Rigidbody>().IsSleeping() ? $"<color=green>{hits}</color>" : $"<color=red>{hits}</color>";
    //}

    // Setzt die score auf einen belibiegen wert und aktualisiert.
    public void SetScore(int score)
    {
        uiText.text = score.ToString();
    }
}
