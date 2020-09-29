using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Quaternion originalRotX, originalRotY, quaternionX, quaternionY; // Вращение
    private Vector3 moveVector; // Направление движения

    public Collider playerColider;
    private CharacterController ch_controller;
    private Camera mainCamera;

    public float gravityFois; // Гравитация
    public float move_up, move_down, move_left, move_right; // Переменые для движения и прыжка
    private float rotX = 0, rotY = 0; // Что-то с вращением (наверно угол, не помню)

    public bool canСontrol = true;
    private bool move_jump; // Возможен ли прыжок?

    // Константы
    public float graviti = 20f; // Гравитация
    public float player_jamp = 7f; // Высота прыжка
    public float mous_sensetiviti; // Чувствитеьность мыши
    private float slide = 0.2f; // Скольжение
    private float inertia = 0.005f; // Инерция в воздухе (чем меньше, тембольше инерция)
    private float player_speed = 4f; // Скорость передвежения
    private float player_moove = 1; // Скорость ходьбы
    private float player_run = 2f; // Скорость бега добовляется к скорости движения


    private void Awake()
    {
        ch_controller = GetComponent<CharacterController>(); // Получаем компонент
        mainCamera = Camera.main;

        if (!PlayerPrefs.HasKey("KeyMotion1"))
            PlayerPrefs.SetString("KeyMotion1", "w");

        if (!PlayerPrefs.HasKey("KeyMotion2"))
            PlayerPrefs.SetString("KeyMotion2", "s");

        if (!PlayerPrefs.HasKey("KeyMotion3"))
            PlayerPrefs.SetString("KeyMotion3", "a");

        if (!PlayerPrefs.HasKey("KeyMotion4"))
            PlayerPrefs.SetString("KeyMotion4", "d");

        if (!PlayerPrefs.HasKey("KeyMotion5"))
            PlayerPrefs.SetString("KeyMotion5", "space");

        if (!PlayerPrefs.HasKey("KeyMotion6"))
            PlayerPrefs.SetString("KeyMotion6", "left shift");

        if (!PlayerPrefs.HasKey("KeyMotion7"))
            PlayerPrefs.SetString("KeyMotion7", "e");

        if (!PlayerPrefs.HasKey("KeyMotion8"))
            PlayerPrefs.SetString("KeyMotion8", "i");

        if (!PlayerPrefs.HasKey("MouseSensitivity"))
            PlayerPrefs.SetFloat("MouseSensitivity", 10);

        if (!PlayerPrefs.HasKey("FieldOfView"))
            PlayerPrefs.SetInt("FieldOfView", 60);
    }

    private void Start()
    {
        // Фиксирует начальные координаты вращения
        originalRotX = transform.localRotation;
        originalRotY = mainCamera.transform.localRotation;

        mainCamera.fieldOfView = PlayerPrefs.GetInt("FieldOfView");
        mous_sensetiviti = PlayerPrefs.GetFloat("MouseSensitivity");

        moveVector = Vector3.zero; // Обнуление вектора движения (чтобы не было случайных ошибок)

        Physics.IgnoreCollision(ch_controller, playerColider);
    }


    private void Update()
    {
        if (canСontrol == true)
        {
            MousVrashenie();
            MovePlayer();

        }
        // Записывает все значения перемещения персонажа в вектор
        {
            moveVector = new Vector3((move_right + move_left) * player_speed, gravityFois, (move_down + move_up) * player_speed);

            moveVector = transform.TransformDirection(moveVector); // Задаём направление движения вектора

            ch_controller.Move(moveVector * Time.deltaTime); // Движение персонажа
        }
    }


    private void FixedUpdate()
    {
        GamingGravity();
    }


    private void GamingGravity()
    {
        // Ускорение свободного падения
        if (!ch_controller.isGrounded) // Если персонаж не касается земли то:
        {
            if (gravityFois > -9.8f)
            {
                gravityFois = gravityFois - (graviti * Time.deltaTime); // Сила гравитации прибовляется
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
        if (Input.GetKey(PlayerPrefs.GetString("KeyMotion6"))) // Нажатие кнопки Бег
        {
            player_moove = player_run; // Скорость движения увеличивается 
        }
        else
        {
            if (Input.GetKeyUp(PlayerPrefs.GetString("KeyMotion6")))
            {
                player_moove = 1; // Скорость движения возвращается в изначальное состояние
            }
        }

        // Движение впрёд
        if (Input.GetKey(PlayerPrefs.GetString("KeyMotion1")) && move_jump == true) // Нажатие кнопки движения
        {
            move_up = +1 * player_moove; // Переменая движения задаёт движение 1 и умножаетнаскорость бега
        }

        // Движение назад 
        if (Input.GetKey(PlayerPrefs.GetString("KeyMotion2")) && move_jump == true)
        {
            move_down = -1 * player_moove;
        }

        // Движение влево
        if (Input.GetKey(PlayerPrefs.GetString("KeyMotion3")) && move_jump == true)
        {
            move_left = -1 * player_moove;
        }

        // Движение вправо
        if (Input.GetKey(PlayerPrefs.GetString("KeyMotion4")) && move_jump == true)
        {
            move_right = +1 * player_moove;
        }

        // Прыжок
        if (Input.GetKey(PlayerPrefs.GetString("KeyMotion5"))) // Если нажат прыжок
        {
            if (move_jump == true) //Если игрок не в воздухе
            {
                gravityFois = player_jamp; // игрок подпрыгивает
                move_jump = false; // Пока игрок в воздухе ему нельзя прыгать
            }
        }
    }


    private void MousVrashenie()
    {
        rotX += Input.GetAxis("Mouse X") * mous_sensetiviti / 5;
        rotY += Input.GetAxis("Mouse Y") * mous_sensetiviti / 5;
        quaternionX = Quaternion.AngleAxis(rotX, Vector3.up);
        quaternionY = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRotX * quaternionX;
        mainCamera.transform.localRotation = originalRotY * quaternionY;
    }

    public void SetMouseSensitivity()
    {
        mous_sensetiviti = PlayerPrefs.GetFloat("MouseSensitivity");
    }
}
