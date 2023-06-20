using System;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitWindow() {
        Debug.Log("Application stopped successfully");
        Application.Quit();
    }
}
