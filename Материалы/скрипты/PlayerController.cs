using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*

    public bool move_jump; // Возможен ли прыжок?
    public float move_up, move_down, move_left, move_right; // Переменые для движения и прыжка
    public float player_run = 1; // Cкорость бега (увеличивается в коде) (умножаемое значение)

    public float rot = 0; // Что-то с вращением (наверно угол, не помню)
    public Quaternion originalRot; // Вращение

    public Vector3 contrileVector; // Направление движения

    public PlayerMovement Movement;




    private float slide = Глобальные_значения.slide; // Небольшое скольжение после остановки персонажа
    private float inertia = Глобальные_значения.inertia; // Инерция движения в воздухе
    private float player_speed = Глобальные_значения.player_speed; // Скорость передвижения

    private GameObject shellRotation;

    private void Start()
    {
        Movement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        originalRot = transform.localRotation; // Фиксирует начальные координаты вращения

        contrileVector = Vector3.zero; // Обнуление вектора движения (чтобы небыо случайных ошибок)

        shellRotation = transform.Find("Player").gameObject;


        rot += Input.GetAxis("Mouse X") * 2 * Глобальные_значения.mous_sensetiviti;
        Quaternion Quaternion = Quaternion.AngleAxis(rot, Vector3.up);
        transform.localRotation = originalRot * Quaternion;
    }


    private void FixedUpdate() // Все движения
    {
        
    }

    private void MovePlayer() // Передвижение персонажа
    {
        if (Input.GetButton("Бег")) // Нажатие кнопки Бег
        {
            player_run = Глобальные_значения.player_run; // Скорость бега увеличивается 
        }
        else
        { player_run = 1; } // Скорость бега возвращается в изначальное состояние

        // Движение впрёд
        if (Input.GetButton("Вперёд") && move_jump == true) // Нажатие кнопки движения
        {
            move_up = +1 * player_run; // Переменая движения задаёт движение 1 и умножаетнаскорость бега
        }
        else
        {
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
        }

        // Движение назад 
        if (Input.GetButton("Назад") && move_jump == true)
        {
            move_down = -1 * player_run;
        }
        else
        {
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
        }

        // Движение влево
        if (Input.GetButton("Влево") && move_jump == true)
        {
            move_left = -1 * player_run;
        }
        else
        {
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
        }

        // Движение вправо
        if (Input.GetButton("Вправо") && move_jump == true)
        {
            move_right = +1 * player_run;
        }
        else
        {
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

        // Прыжок
        if (Input.GetButton("Прыжок")) // .Если нажат прыжок
        {
            if (move_jump == true) //Если игрок не в воздухе
            {
                Movement.gravityFois = Глобальные_значения.player_jamp; // игрок подпрыгивает
                move_jump = false; // Пока игрок в воздухе ему нельзя прыгать
            }
        }


        // Записывает все значения в вектор
        contrileVector = new Vector3((move_right + move_left) * player_speed, Movement.gravityFois, (move_down + move_up) * player_speed);

        contrileVector = transform.TransformDirection(contrileVector); // Задаём направление движения вектора

        
    }
    */
    /*
    public PlayerMovement Movement;
    public Vector3 contrileVector = Vector3.zero; // Направление движения

    public bool move_jump; // Возможен ли прыжок?
    public float move_up, move_down, move_left, move_right; // Переменые для движения и прыжка
    public float player_run; // Cкорость бега (увеличивается в коде) (умножаемое значение)
    private float player_speed; // Скорость передвижения

    private void Awake()
    {
        Movement = GameObject.FindGameObjectWithTag("PlayerSM").GetComponent<PlayerMovement>();
        player_speed = Глобальные_значения.player_speed;
        player_run = Глобальные_значения.player_run;
    }


    private void Start()
    {
        
        move_jump = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer() // Передвижение персонажа
    {
        if (Input.GetButton("Бег")) // Нажатие кнопки Бег
        {
            player_run = Глобальные_значения.player_run; // Скорость бега увеличивается 
        }
        else
        { player_run = 1; } // Скорость бега возвращается в изначальное состояние

        // Движение впрёд
        if (Input.GetButton("Вперёд") && move_jump == true) // Нажатие кнопки движения
        {
            move_up = +1 * player_run; // Переменая движения задаёт движение 1 и умножаетнаскорость бега
        }
        else
        {
            ////1
        }

        // Движение назад 
        if (Input.GetButton("Назад") && move_jump == true)
        {
            move_down = -1 * player_run;
        }
        else
        {
           ////2
        }

        // Движение влево
        if (Input.GetButton("Влево") && move_jump == true)
        {
            move_left = -1 * player_run;
        }
        else
        {
            ////3
        }

        // Движение вправо
        if (Input.GetButton("Вправо") && move_jump == true)
        {
            move_right = +1 * player_run;
        }
        else
        {
            ////4
        }

        // Прыжок
        if (Input.GetButton("Прыжок")) // .Если нажат прыжок
        {
            

            if (move_jump == true) //Если игрок не в воздухе
            {
                Movement.gravityFois = Глобальные_значения.player_jamp; // игрок подпрыгивает
                move_jump = false; // Пока игрок в воздухе ему нельзя прыгать
            }

        }

        //Movement.gravityFois
        contrileVector = new Vector3((move_right + move_left) * player_speed, Movement.gravityFois, (move_down + move_up) * player_speed);
        
    }

    */
}