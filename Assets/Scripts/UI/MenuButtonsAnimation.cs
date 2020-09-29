using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonsAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip bottonActive;
    public PauseMenu pauseMenu;
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

    public void BottonClick(int idBotton)
    {
        BottonUnActiv();

        pauseMenu.BottonClick(idBotton);
    }

    void BottonActiv()
    {
        // Изменение цвета кнопки
        colBotton = GetComponent<Image>().color;
        colBotton.a = 0.4f;
        image.color = colBotton;

        // Запуск звука
        audioB.clip = bottonActive;
        audioB.Play();
    }

    void BottonUnActiv()
    {
        // Возвращение цвета кнопки
        colBotton.a = 1;
        image.color = colBotton;
    }
}
