using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerOther : MonoBehaviour
{
    public Camera main_camera;
    public GameObject sphere;
    public PlayerMove player;
    RaycastHit hit;

    Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    private void releaseRay()
    {
        // Сам луч
        Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);
        // Запись объекта, в который пришел луч, в переменную
        
        Physics.Raycast(ray, out hit);

        //Debug.Log(hit.point);
        sphere.transform.position = hit.point;
    }


    void Update()
    {
        if (Input.GetKey("mouse 0"))
        {
            releaseRay();
        player.Move(hit.point);
        }


    }

}
