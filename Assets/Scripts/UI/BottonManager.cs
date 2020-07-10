using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonManager : MonoBehaviour
{
    public PauseMenu pauseMenu;

    public void ResumeGame()
    {
        pauseMenu.Resume();
    }

    public void EciExitToMenu()
    {

    }
}
