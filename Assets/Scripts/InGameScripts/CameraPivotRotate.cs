using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotRotate : MonoBehaviour
{
    
    [SerializeField] private List<Transform> _cameraPositions; //Создаём список позиций, чтобы менять позицию и вращение камеры между ними 
    private Transform _currentPosition;
    [SerializeField] private Transform _cameraPivot;
    public int _positionInList;

    private void Start()
    {
        _positionInList = 0;
        _currentPosition = _cameraPositions[0];
    }

    //Присвоение позиции камеры к позициям в списке
    private void Update()
    {
        _cameraPivot.position = _currentPosition.position;
        _cameraPivot.rotation = _currentPosition.rotation;
    }

    //Поворот камеры налево
    public void LeftRotate()
    {
        _positionInList++;
        if (_positionInList >= _cameraPositions.Count) _positionInList = 0;
        _currentPosition = _cameraPositions[_positionInList];
    }

    //Поворот камеры направо
    public void RightRotate()
    {
        if (_positionInList <= 0) _positionInList = _cameraPositions.Count;
        _positionInList--;
        _currentPosition = _cameraPositions[_positionInList];
    }
}
