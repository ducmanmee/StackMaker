using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private  Vector3 currentVelocity = Vector3.zero;
    private Vector3 targetPosition;


    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}
