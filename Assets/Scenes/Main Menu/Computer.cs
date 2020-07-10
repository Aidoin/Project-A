using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{

    public GameObject windowPlayGame;
    public GameObject windowSettings;
    public GameObject windowExit;

    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            windowPlayGame.SetActive(false);
            windowSettings.SetActive(false);
            windowExit.SetActive(false);
        }
    }

    public void ShowPanel(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void HidePanel(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
