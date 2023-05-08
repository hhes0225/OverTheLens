using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseHelpWindow : MonoBehaviour
{
    public GameObject helpWindow;
    private bool _active;
    
    public void OpenCloseWindow()
    {
        if (_active == false)
        {
            Time.timeScale = 0;         //if player click UI button, then game will be paused 
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        _active = !_active;
        helpWindow.SetActive(_active);
    }
}
