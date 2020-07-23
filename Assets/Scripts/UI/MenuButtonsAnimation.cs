using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonsAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip BottonActive, BottonKlick;
    public PauseBottonManager bm;
    AudioSource audioB;
    Image image;
    Color colBotton; // Переменая для изменения цвета

    void Start()
    {
        audioB = GetComponent<AudioSource>();
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        BottonActiv();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BottonUnActiv();
    }

    public void BottonClick(int botton)
    {
        // Проигрывается звук нажатия
        bm.BottonClick(this);

        BottonUnActiv();

        if (botton == 1)
        {
            bm.ResumeGame();
        }
        else
        if (botton == 2)
        {

        }
        else
        if (botton == 3)
        {

        }
        else
        if (botton == 4)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void BottonActiv()
    {
        // Изменение цвета кнопки
        colBotton = GetComponent<Image>().color;
        colBotton.a = 0.4f;
        image.color = colBotton;

        // Запуск звука
        audioB.clip = BottonActive;
        audioB.Play();
    }

    void BottonUnActiv()
    {
        // Возвращение цвета кнопки
        colBotton.a = 1;
        image.color = colBotton;
    }
}
