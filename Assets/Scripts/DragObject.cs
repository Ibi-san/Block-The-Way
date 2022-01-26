using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        //��� ������� �� ������� � ��� ������������, ��������� �������� � ����������� �������� ����(������) � ���������� � ������� ��� ���������� � ��������� ����

        float distanceX = Input.GetAxis("Mouse X");  
        if (distanceX != 0)
            _rigidbody.AddForce(distanceX, 0, 0, ForceMode.VelocityChange); 

        float distanceZ = Input.GetAxis("Mouse Y");
        if (distanceZ != 0)
            _rigidbody.AddForce(0, 0, distanceZ, ForceMode.VelocityChange);

    }

    private void OnMouseDown()
    {
        //��� ������� �������� �������� ������ ����� ����� ������
        GetComponent<Renderer>().material.color = new Color(1f, 0.33f, 0f);
    }

    private void OnMouseUp()
    {
        //���� ���������� ������� ������������ � �������� ���������
        GetComponent<Renderer>().material.color = new Color(0.87f, 0.54f, 0.38f);
    }

    
}
