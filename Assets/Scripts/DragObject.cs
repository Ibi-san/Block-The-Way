using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class DragObject : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _sensetivity;
    [SerializeField] private float _objectMaxSpeed = 200f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude > _objectMaxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _objectMaxSpeed;
        }
    }
    private void OnMouseDrag()
    {
        //При нажатии на предмет и его передвижении, сохраняем величину и направление движения мыши(пальца) в переменную и передаём эту переменную в двигающую силу

        float distanceX = Input.GetAxis("Mouse X") * Time.deltaTime;
        //float _distanceX = Mathf.Clamp(distanceX, -1f, 1f) * Time.deltaTime;
        Debug.Log(distanceX);
        if (distanceX != 0)
            _rigidbody.AddForce(distanceX * _sensetivity, 0, distanceX * _sensetivity, ForceMode.VelocityChange); 

        float distanceZ = Input.GetAxis("Mouse Y") * Time.deltaTime;
        if (distanceZ != 0)
            _rigidbody.AddForce(-distanceZ * _sensetivity, 0, distanceZ * _sensetivity, ForceMode.VelocityChange);

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

    
}
