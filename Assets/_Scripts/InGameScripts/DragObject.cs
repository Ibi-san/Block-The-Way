using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class DragObject : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _sensetivity;
    private float _objectSpeed;
    public CameraPivotRotate cameraPosition;

    private void Awake()
    {
        _objectSpeed += Time.deltaTime * _sensetivity * 10f;
        _rigidbody = GetComponent<Rigidbody>();
    }

    
    private void OnMouseDrag()
    {
        //При нажатии на предмет и его передвижении, сохраняем величину и направление движения мыши(пальца) в переменную и передаём эту переменную в двигающую силу
        if (cameraPosition._positionInList == 0) Position1();
        if (cameraPosition._positionInList == 1) Position2();
        if (cameraPosition._positionInList == 2) Position3();
        if (cameraPosition._positionInList == 3) Position4();
    }

    private void OnMouseDown()
    {
        //При нажатии выделяем активный объект более ярким цветом
        GetComponent<Renderer>().material.color = new Color(1f, 0.33f, 0f);
    }

    private void OnMouseUp()
    {
        //Цвет выбранного объекта возвращается в исходное положение
        GetComponent<Renderer>().material.color = new Color(0.87f, 0.54f, 0.38f);
    }

    private void Position1()
    {
        float distanceX = Input.GetAxis("Mouse X") * Time.deltaTime;
        if (distanceX != 0)
            _rigidbody.AddForce(distanceX * _objectSpeed, 0, distanceX * _objectSpeed, ForceMode.VelocityChange);

        float distanceZ = Input.GetAxis("Mouse Y") * Time.deltaTime;
        if (distanceZ != 0)
            _rigidbody.AddForce(-distanceZ * _objectSpeed, 0, distanceZ * _objectSpeed, ForceMode.VelocityChange);
    }

    private void Position2()
    {
        float distanceX = Input.GetAxis("Mouse X") * Time.deltaTime;
        if (distanceX != 0)
            _rigidbody.AddForce(distanceX * _objectSpeed, 0, -distanceX * _objectSpeed, ForceMode.VelocityChange);

        float distanceZ = Input.GetAxis("Mouse Y") * Time.deltaTime;
        if (distanceZ != 0)
            _rigidbody.AddForce(distanceZ * _objectSpeed, 0, distanceZ * _objectSpeed, ForceMode.VelocityChange);
    }

    private void Position3()
    {
        float distanceX = Input.GetAxis("Mouse X") * Time.deltaTime;
        if (distanceX != 0)
            _rigidbody.AddForce(-distanceX * _objectSpeed, 0, -distanceX * _objectSpeed, ForceMode.VelocityChange);

        float distanceZ = Input.GetAxis("Mouse Y") * Time.deltaTime;
        if (distanceZ != 0)
            _rigidbody.AddForce(distanceZ * _objectSpeed, 0, -distanceZ * _objectSpeed, ForceMode.VelocityChange);
    }

    private void Position4()
    {
        float distanceX = Input.GetAxis("Mouse X") * Time.deltaTime;
        if (distanceX != 0)
            _rigidbody.AddForce(-distanceX * _objectSpeed, 0, distanceX * _objectSpeed, ForceMode.VelocityChange);

        float distanceZ = Input.GetAxis("Mouse Y") * Time.deltaTime;
        if (distanceZ != 0)
            _rigidbody.AddForce(-distanceZ * _objectSpeed, 0, -distanceZ * _objectSpeed, ForceMode.VelocityChange);
    }
}
