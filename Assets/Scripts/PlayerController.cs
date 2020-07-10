using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Collider playerColider;

    private Quaternion originalRotX, originalRotY; // Вращение
    private Vector3 moveVector; // Направление движения

    private CharacterController ch_controller;
    private Camera mainCamera;

    private Settings settings;

    public bool canСontrol = true;
    private bool move_jump; // Возможен ли прыжок?
    private float rotX = 0, rotY = 0; // Что-то с вращением (наверно угол, не помню)
    public float gravityFois; // Гравитация
    public float move_up, move_down, move_left, move_right; // Переменые для движения и прыжка
    private float slide;
    private float inertia;
    private float player_speed;
    private float player_run;
    



    Quaternion QuaternionX, QuaternionY;

    private void Awake()
    {
        ch_controller = GetComponent<CharacterController>(); // Получаем компонент
        mainCamera = Camera.main;

        settings = GameObject.FindGameObjectWithTag("World").GetComponent<Settings>();
        slide = settings.slide;
        inertia = settings.inertia;
        player_speed = settings.player_speed;
        player_run = settings.player_run;
    }

    private void Start()
    {
        // Фиксирует начальные координаты вращения
        originalRotX = transform.localRotation;
        originalRotY = mainCamera.transform.localRotation;

        moveVector = Vector3.zero; // Обнуление вектора движения (чтобы небыо случайных ошибок)

        Physics.IgnoreCollision(this.ch_controller, playerColider);

    }
    

    private void FixedUpdate() // Все движения
    {
        GamingGravity();
    }


    private void Update()
    {
        if (canСontrol == true)
        {
            MousVrashenie();
            MovePlayer();

        }
        // Записывает все значения в вектор
        {
            moveVector = new Vector3((move_right + move_left) * player_speed, gravityFois, (move_down + move_up) * player_speed);

            moveVector = transform.TransformDirection(moveVector); // Задаём направление движения вектора

            ch_controller.Move(moveVector * Time.deltaTime); // Движение персонажа
        }
    }


    private void GamingGravity()
    {
        // Ускорение свободного падения
        if(!ch_controller.isGrounded) // Если персонаж не касается земли то:
        {
            if (gravityFois > -9.8f)
            {
                gravityFois = gravityFois - (settings.graviti * Time.deltaTime); // Сила гравитации прибовляется
            }
        }
        else // Если он на земле, то:
        {
            gravityFois = -1; // Гравитация равна -1
            move_jump = true; // Игрок может прыгнуть
        }

        /// Энерция движения
        {
            //Вперёд
            if (move_up != 0 && move_up > 0) //Если движение не равно 0 и больше 0
            {
                if (move_jump == true) // Если игрок на замле
                {
                    move_up -= slide; // Движение замедляется до остановки
                }
                else // Если игрок в воздухе
                { move_up -= inertia; } // Движение медленно замедляется (типо сопротевление воздуха)
            }
            else // Если движение уходит в минус (ошибка)
            { move_up = 0; } // Движение обнуляется

            //Назад
            if (move_down != 0 && move_down < 0)
            {
                if (move_jump == true)
                {
                    move_down += slide;
                }
                else
                { move_down += inertia; }
            }
            else
            { move_down = 0; }

            //Лево
            if (move_left != 0 && move_left < 0)
            {
                if (move_jump == true)
                {
                    move_left += slide;
                }
                else { move_left += inertia; }
            }
            else
            { move_left = 0; }

            //Право
            if (move_right != 0 && move_right > 0)
            {
                if (move_jump == true)
                {
                    move_right -= slide;
                }
                else { move_right -= inertia; }
            }
            else
            { move_right = 0; }
        }


    }


    private void MovePlayer() // Передвижение персонажа
    {
        if (Input.GetButton("Бег")) // Нажатие кнопки Бег
        {
            player_run = settings.player_run; // Скорость бега увеличивается 
        } else 
        { player_run = 1; } // Скорость бега возвращается в изначальное состояние

        // Движение впрёд
        if (Input.GetButton("Вперёд") && move_jump == true) // Нажатие кнопки движения
        {
            move_up = + 1 * player_run; // Переменая движения задаёт движение 1 и умножаетнаскорость бега
        }

        // Движение назад 
        if (Input.GetButton("Назад") && move_jump == true) 
        { 
            move_down = - 1 * player_run;
        }

        // Движение влево
        if (Input.GetButton("Влево") && move_jump == true) 
        { 
            move_left = - 1 * player_run; 
        }

        // Движение вправо
        if (Input.GetButton("Вправо") && move_jump == true)  
        { 
            move_right = + 1* player_run; 
        }

        // Прыжок
        if (Input.GetButton("Прыжок")) // Если нажат прыжок
        {
            if (move_jump == true) //Если игрок не в воздухе
            {
                gravityFois = settings.player_jamp; // игрок подпрыгивает
                move_jump = false; // Пока игрок в воздухе ему нельзя прыгать
            }
        }

    }

    private void MousVrashenie()
    {
        rotX += Input.GetAxis("Mouse X") * settings.mous_sensetiviti;
        rotY += Input.GetAxis("Mouse Y") * settings.mous_sensetiviti;
        QuaternionX = Quaternion.AngleAxis(rotX, Vector3.up);
        QuaternionY = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRotX * QuaternionX;
        mainCamera.transform.localRotation = originalRotY * QuaternionY;
    }
}
