using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashGameEnding : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject CrashTrigger;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("game crashed!");
        Application.Quit();
    }
}
