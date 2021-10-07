using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Управление_персонажем : MonoBehaviour
{

    private CharacterController ch_controller; // Ссылка на компонент
    private Vector3 moveVector; // Направление движения
    void Start()
    {
        ch_controller = GetComponent<CharacterController>(); // Получаем компонент
    }

   
    void Update()
    {
        if(Input.GetButton("Вперёд"))
        {
            moveVector.x = 1;
            ch_controller.Move(moveVector * Time.deltaTime); // Само движение
        }
    }
}
