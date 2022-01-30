using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotRotate : MonoBehaviour
{
    
    [SerializeField] private List<Transform> _cameraPositions; //������ ������ �������, ����� ������ ������� � �������� ������ ����� ���� 
    private Transform _currentPosition;
    [SerializeField] private Transform _cameraPivot;
    public int _positionInList;

    private void Start()
    {
        _positionInList = 0;
        _currentPosition = _cameraPositions[0];
    }

    //���������� ������� ������ � �������� � ������
    private void Update()
    {
        _cameraPivot.position = _currentPosition.position;
        _cameraPivot.rotation = _currentPosition.rotation;
    }

    //������� ������ ������
    public void LeftRotate()
    {
        _positionInList++;
        if (_positionInList >= _cameraPositions.Count) _positionInList = 0;
        _currentPosition = _cameraPositions[_positionInList];
    }

    //������� ������ �������
    public void RightRotate()
    {
        if (_positionInList <= 0) _positionInList = _cameraPositions.Count;
        _positionInList--;
        _currentPosition = _cameraPositions[_positionInList];
    }
}
