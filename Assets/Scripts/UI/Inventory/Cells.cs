using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cells : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public Sprite cellActive;
    Sprite cell; 
    Image img;

    void Start()
    {
        img = GetComponent<Image>();
        cell = img.sprite;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        img.sprite = cellActive;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.sprite = cell;
    }

    private void OnDisable()
    {
        img.sprite = cell;
    }

}
