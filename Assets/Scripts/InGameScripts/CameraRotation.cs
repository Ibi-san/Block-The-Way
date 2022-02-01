using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    //float smooth = 10.0f;
    //float tiltAngle = 90.0f;
    Vector3 startPoint;
    Vector3 endRightPoint;
    Vector3 endLeftPoint;

    private void Start()
    {
        startPoint = transform.position;
        endRightPoint = new Vector3(9.6f, startPoint.y, startPoint.z);
        endLeftPoint = new Vector3(9.6f, 1.5f, startPoint.z);
    }
    private void Update()
    {
        
            //float tiltAroundY = Input.GetTouch(0).deltaPosition.x * tiltAngle;
            //Quaternion target = Quaternion.Euler(30, tiltAroundY - 45, 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);


            //if (Input.GetTouch(0).deltaPosition.x > 0)
            //{
            //    StartCoroutine(LerpPosition(endLeftPoint, 0.5f));
            //}

            //if (Input.GetTouch(0).deltaPosition.x < 0)
            //{
            //    StartCoroutine(LerpPosition(endRightPoint, 0.5f));
            //}

            //else
            //{
            //    float step = smooth * Time.deltaTime;
            //    transform.position = Vector3.MoveTowards(transform.position, startPoint, step);
            //}
        }

    

    //private void LeftRotate()
    //{
    //    StartCoroutine(LerpPosition(endLeftPoint, 0.5f));
    //}

    //private void RightRotate()
    //{
    //    StartCoroutine(LerpPosition(endRightPoint, 0.5f));
    //}

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
