using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Movement")]
    public float s_speed;
    public float s_jumpLength;
    public float s_gravity;
    public float SmoothDelta = 0.4f;
    private Vector3 p_direction = Vector3.zero;

    private CharacterController p_char;

    [Header("MouseMovent")]
    public float s_sensitivity;

    private float p_angleX;
    private float p_angleY;

    public Transform s_camera;

    private Quaternion p_camQ;
    private Quaternion p_charQ;



    void Start()
    {
        s_camera = Camera.main.transform;
        p_char = GetComponent<CharacterController>();

        p_camQ = s_camera.rotation;
        p_charQ = transform.rotation;
    }

    void FixedUpdate()
    {
        p_angleX += Input.GetAxis("Mouse X") * s_sensitivity;
        p_angleY += Input.GetAxis("Mouse Y") * s_sensitivity;

        p_angleY = Mathf.Clamp(p_angleY, -70.0f, 70.0f);

        Quaternion delta = p_camQ * Quaternion.AngleAxis(p_angleX, Vector3.up) * Quaternion.AngleAxis(p_angleY, Vector3.left);
        s_camera.rotation = Quaternion.Lerp(s_camera.rotation, delta, SmoothDelta);
        transform.rotation = Quaternion.Lerp(transform.rotation, p_charQ * Quaternion.AngleAxis(p_angleX, Vector3.up), SmoothDelta);
    }

    void Update()
    {
        if(p_char.isGrounded)
        {
            if(Input.GetButton("Vertical"))
            {
                p_direction += Input.GetAxis("Vertical") * transform.forward;
            }
            if(Input.GetButton("Horizontal"))
            {
                p_direction += Input.GetAxis("Horizontal") * transform.right;
            }
            if(Input.GetButton("Jump"))
            {
                p_direction.y = s_jumpLength;
            }
            p_direction *= s_speed * Time.deltaTime;
            p_char.Move(p_direction);
        }else
        {
            p_direction.y -= s_gravity * Time.deltaTime;
            p_char.Move(p_direction);
        }

    }
}
