using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBottonManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public AudioSource audioB;

    private void Start()
    {
        audioB = GetComponent<AudioSource>();
    }


    public void BottonClick(MenuButtonsAnimation botton)
    {
        audioB.clip = botton.BottonKlick;
        audioB.Play();
    }
    public void ResumeGame()
    {
        pauseMenu.Resume();
    }
}
