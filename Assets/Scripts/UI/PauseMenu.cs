using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public GameObject inventory;
    public GameObject point;
    public PlayerController player;


    void Start()
    {
        container.SetActive(false);
        Cursor.visible = false;
    }


    void Update()
    {
        // ToggleMainMenu
        if (Input.GetButtonDown("Cancel"))
        {
            if (container.activeSelf)
            {
                Resume();
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                container.SetActive(true);
                inventory.SetActive(false);
                point.SetActive(false);
                Time.timeScale = 0;
                player.canСontrol = false;
            }
        }
    }


    public void Resume()
    {
        container.SetActive(false);
        point.SetActive(true);
        player.canСontrol = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }




}
