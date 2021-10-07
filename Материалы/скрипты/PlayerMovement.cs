using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    /* 
     private CharacterController ch_controller;
     public PlayerController Controller;
     public Vector3 moveVector = Vector3.zero; // Вектор движения
     public float gravityFois = -1; // Гравитация

     private void Start()
     {
         ch_controller = GetComponent<CharacterController>(); // Получаем компонент характерконтроллера
         Controller = GameObject.Find("Shell Movements Player").GetComponent<PlayerController>(); // Получаем скрипт управления
     }

     private void FixedUpdate()
     {
         GamingGravity();

         ch_controller.Move((moveVector + Controller.contrileVector) * Time.deltaTime); // Движение персонажа

     }

     private void GamingGravity()
     {
         if (!ch_controller.isGrounded) // Если персонаж не касается земли то:
         {
             gravityFois = gravityFois - (Глобальные_значения.graviti * Time.deltaTime); // Сила гравитации прибовляется
         }
         else // Если он на земле, то:
         {
             gravityFois = -1; // Гравитация равна -1
             Controller.move_jump = true; // Игрок может прыгнуть
         }

     }
     */
     /*

    private CharacterController ch_controller;
    private PlayerController Controller;

    private Vector3 moveVector = Vector3.zero; // Вектор движения

    public float move_up, move_down, move_left, move_right; // Переменые для движения
    private float slide = Глобальные_значения.slide; // Небольшое скольжение после остановки персонажа
    private float inertia = Глобальные_значения.inertia; // Инерция движения в воздухе

    public float gravityFois = -1; // Гравитация

    private void Start()
    {
        ch_controller = GetComponent<CharacterController>(); // Получаем компонент характерконтроллера
        Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // Получаем скрипт управления

        gravityFois = -1;
    }

    private void FixedUpdate()
    {
        

        GamingGravity();
    }

    private void GamingGravity()
    {
        ////1
        if (move_up != 0 && move_up > 0) //Если движение не равно 0 и больше 0
        {
            if (Controller.move_jump == true) // Если игрок на замле
            {
                move_up -= slide; // Движение замедляется до остановки
            }
            else // Если игрок в воздухе
            { move_up -= inertia; } // Движение медленно замедляется (типо сопротевление воздуха)
        }
        else // Если движение уходит в минус (ошибка)
        { move_up = 0; } // Движение обнуляется




        ////2
        if (move_down != 0 && move_down < 0)
        {
            if (Controller.move_jump == true)
            {
                move_down += slide;
            }
            else
            { move_down += inertia; }
        }
        else
        { move_down = 0; }




        ////3
        if (move_left != 0 && move_left < 0)
        {
            if (Controller.move_jump == true)
            {
                move_left += slide;
            }
            else { move_left += inertia; }
        }
            else
        { move_left = 0; }


        ////4
        if (move_right != 0 && move_right > 0)
        {
            if (Controller.move_jump == true)
            {
                move_right -= slide;
            }
            else { move_right -= inertia; }
        }
        else
        { move_right = 0; }

        //contrileVector = new Vector3((move_right + move_left) * player_speed, Movement.gravityFois, (move_down + move_up) * player_speed);







        if (!ch_controller.isGrounded) // Если персонаж не касается земли то:
        {
            gravityFois = gravityFois - (Глобальные_значения.graviti * Time.deltaTime); // Сила гравитации прибовляется
        }
        else // Если он на земле, то:
        {
            gravityFois = -1; // Гравитация равна -1
            Controller.move_jump = true; // Игрок может прыгнуть
        }



        if (Controller.contrileVector == Vector3.zero)
        {
            moveVector += Controller.contrileVector;

            ch_controller.Move(moveVector * Time.deltaTime); // Движение персонажа
        }


    }

    */
}