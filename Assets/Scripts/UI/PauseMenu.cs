using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public GameObject inventory;
    public GameObject point;
    public PlayerController player;
    public AudioSource audioKlick;
    public PauseMenuBotton pauseMenuBotton;

    void Start()
    {
        container.SetActive(false);
        Cursor.visible = false;
    }

    public void BottonClick(int idBotton)
    {
        audioKlick.Play();

        if (idBotton == 0)
        {
            Resume();
        }
        else
        if (idBotton == 3)
        {
            SceneManager.LoadScene("MainMenu");
        }
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
                inventory.transform.GetChild(0).gameObject.SetActive(false);
                inventory.SetActive(false);
                point.SetActive(false);
                Time.timeScale = 0;
                player.canСontrol = false;
            }
        }
    }


    public void Resume()
    {
        pauseMenuBotton.HidePanel();
        inventory.SetActive(true);

        // Отключает изменение управления при выходе из паузы через Escape
        container.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.GetComponent<KeyboardAndMouseSettings>().UndoChanges();

        container.SetActive(false);
        point.SetActive(true);
        player.canСontrol = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }




}
