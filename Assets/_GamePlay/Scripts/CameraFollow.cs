using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public static CameraFollow instance; 
    
    private Vector3 offset;
    private Vector3 originalPos;
    private Quaternion originalRotation;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private  Vector3 currentVelocity = Vector3.zero;
    private Vector3 targetPosition;
    private Vector3 winOffset;

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Awake()
    {
        MakeInstance();
        originalPos = transform.position;
        originalRotation = transform.rotation;
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {

        if(!GameManager.Instance.isWin)
        {
            targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        }
        else
        {
            winOffset = new Vector3(offset.x - 6f, offset.y - 6f, offset.z);
            targetPosition = target.position + winOffset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime * 2f);
            transform.LookAt(target);
        }    
    }

    public void SetOriginalPos()
    {
        transform.position = originalPos;
        transform.rotation = originalRotation;
    }
}
