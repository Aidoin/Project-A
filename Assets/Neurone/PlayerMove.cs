using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public GameObject Player;
    public Rigidbody rb;
    public new Vector3 q;
    Rigidbody playerRb;
    public Vector3 posB, posA, move;


    [SerializeField]
    private float _mouseSensitivity = 0.4f;
    [SerializeField]
    private float _moveSpeed = 2f;

    private Vector3 _mousePreveousePos;
    private float _rotationX;
    private float _rotationY;

    private void Awake()
    {
        Physics.IgnoreCollision(this.GetComponent<Collider>(), Player.GetComponent<Collider>());
        playerRb = Player.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
        posB = posA = this.transform.position;
        rb = GetComponent<Rigidbody>();

    }

    public void Move(Vector3 hit)
    {
        posB = hit;
    }


    void FixedUpdate()
    {
        posA = this.transform.position;
        move = posB - posA;
        move.y = 0;

        ////////////////////////////////////////////////////////////////////////////////////////Debug.Log("до " + Math.Abs(move.x));

        if (Math.Abs(move.x) < 0.01)
        {
            if (Math.Abs(move.z) < 0.01)
            {
                posB = posA;
                move = new Vector3(0,0,0);
            }
        }

        move = move.normalized;

        //////////////////////////////////////////////////////////////////////////////////////////Debug.Log("после " + move.x);
        //rb.AddForce(move.x, posA.y, move.z);

        //Vector3 offset = new Vector3(move.x, posA.y, move.z) * Time.deltaTime;
        //transform.Translate(offset);


        rb.MovePosition(transform.position + move * Time.deltaTime * 5);

        //Debug.Log(move.x +" "+ posA.y+" "+ move.z);

        Quaternion wer = transform.rotation;

        Quaternion deltaRotation = Quaternion.Euler(wer * q * Time.deltaTime * 5);
        playerRb.MoveRotation(playerRb.rotation * deltaRotation);






        //posA = this.transform.position;
        //move = posB - posA;


        ////if (Math.Abs(move.x) > 0.1)
        ////{
        ////    if (move.x > 0)
        ////        move.x = 1;
        ////    if (move.x < 0)
        ////        move.x = -1;
        ////}
        ////if (Math.Abs(move.x) > 0.1)
        ////{
        ////    if (move.z > 0)
        ////        move.z = 1;
        ////    if (move.z < 0)
        ////        move.z = -1;
        ////}

        ////Debug.Log(move);

        ////i = Math.Abs(i);

        ////Debug.Log(Time.deltaTime);

        //Vector3 offset = new Vector3(move.x, 0, move.z) * Time.unscaledDeltaTime * Time.deltaTime;
        //transform.Translate(offset);
        //Rotate();
    }










    //public void Move1()
    //{

    //    float shiftMult = 1f;
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        shiftMult = 3f;
    //    }

    //    float right = Input.GetAxis("Horizontal");
    //    float forward = Input.GetAxis("Vertical");
    //    float up = 0;
    //    if (Input.GetKey(KeyCode.E))
    //    {
    //        up = 1f;
    //    }
    //    else if (Input.GetKey(KeyCode.C))
    //    {
    //        up = -1f;
    //    }

    //    Vector3 offset = new Vector3(right, up, forward) * _moveSpeed * shiftMult * Time.unscaledDeltaTime;
    //    transform.Translate(offset);
    //}




    private float rotX = 0, rotY = 0; // Что-то с вращением (наверно угол, не помню)
    private Quaternion originalRotX, originalRotY, quaternionX, quaternionY; // Вращение

    public void Rotate()
    {

        transform.localRotation = new Quaternion(0,0,0,1);





        //rotX += Input.GetAxis("Mouse X") * 5 / 5;
        //rotY += Input.GetAxis("Mouse Y") * 5 / 5;
        //rotY = Mathf.Clamp(rotY, -80, 80);
        //quaternionX = Quaternion.AngleAxis(rotX, Vector3.up);
        //quaternionY = Quaternion.AngleAxis(rotY, Vector3.left);

        //transform.localRotation = originalRotX * quaternionX;
        //transform.localRotation = originalRotY * quaternionY;


        


        //Vector3 _mouseDelta;

        //if (Input.GetMouseButtonDown(1))
        //{
        //    _mousePreveousePos = Input.mousePosition;
        //}

        //if (Input.GetMouseButton(1))
        //{
        //    _mouseDelta = Input.mousePosition - _mousePreveousePos;
        //    _mousePreveousePos = Input.mousePosition;

        //    _rotationX -= _mouseDelta.y * _mouseSensitivity;
        //    _rotationY += _mouseDelta.x * _mouseSensitivity;

        //    transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0f);
        //}
    }

}
