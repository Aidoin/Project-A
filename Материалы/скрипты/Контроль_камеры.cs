using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Контроль_камеры : MonoBehaviour
{
    /*
    public float min = -80, max = 80; // Ограничения по повороту

    private Quaternion originalRot; // Хз что делаем ну типо включаем вращение
    private float rot = 0; // Переменая для вращения


    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();  //получение компонента тела

        if (rb)
        {
            rb.freezeRotation = true; // Ограничеваем вращение тела с камерой если оно есть
        }
        originalRot = transform.localRotation; // Вроде получаем нынешнее направление
    }


    private void Update()
    {
        rot += Input.GetAxis("Mouse Y") * Глобальные_значения.mous_sensetiviti; // Берём значение передвижение мыши и добовляем чувствительности
        
        rot = rot % 360; // Попровляем чувствительность
        
        rot = Mathf.Clamp(rot, min, max); // Ограничевем обзор
        
        Quaternion yQuaternion = Quaternion.AngleAxis(rot, Vector3.left); // Хз, не помню

        transform.localRotation = originalRot * yQuaternion; // Наверно сам поворот
    }
    */
}
