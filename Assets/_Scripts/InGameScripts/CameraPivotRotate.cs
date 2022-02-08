using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotRotate : MonoBehaviour
{
    
    [SerializeField] private List<Transform> _cameraPositions; //������ ������ �������, ����� ������ ������� � �������� ������ ����� ���� 
    private Transform _currentPosition;
    [SerializeField] private Transform _cameraPivot;
    public int _positionInList;
    [SerializeField] private float _speed = 2f;

    private void Start()
    {
        _positionInList = 0;
        _currentPosition = _cameraPositions[0];
    }

    //���������� ������� ������ � �������� � ������
    private void Update()
    {
        _cameraPivot.position = Vector3.Lerp(_cameraPivot.position, _currentPosition.position, _speed * Time.deltaTime);
        _cameraPivot.rotation = Quaternion.Lerp(_cameraPivot.rotation, _currentPosition.rotation, _speed * Time.deltaTime);
    }

    //������� ������ ������
    public void LeftRotate()
    {
        _positionInList++;
        if (_positionInList >= _cameraPositions.Count) 
            _positionInList = 0;
        _currentPosition = _cameraPositions[_positionInList];
    }

    //������� ������ �������
    public void RightRotate()
    {
        if (_positionInList <= 0) 
            _positionInList = _cameraPositions.Count;
        _positionInList--;
        _currentPosition = _cameraPositions[_positionInList];
    }

    public void DefaultPosition()
    {
        _positionInList = 0;
        _currentPosition = _cameraPositions[0];
    }
}
