using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public static SwipeController instance;

    private void makeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }    
    private Vector3 firstPoint;
    private Vector3 lastPoint;
    private Vector2 direction;

    private float deltaX;
    private float deltaY;

    public Direct swipeDirection = Direct.Null;
    public enum Direct
    {
        Null = -1,
        Forward  = 0,
        Backward = 1,
        Left = 2,
        Right = 3,
    }

    private void Awake()
    {
        makeInstance();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerMovement.instance.canMove)
        {
            getSwipeDirection();
        }
    }

    private void getSwipeDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPoint = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastPoint = Input.mousePosition;
            direction = lastPoint - firstPoint;
            if (direction.magnitude > 50f && GameManager.Instance.canSwipe)
            {
                PlayerManager.instance.audioSource.PlayOneShot(PlayerManager.instance.swipeClip);
                deltaX = Mathf.Abs(direction.x);
                deltaY = Mathf.Abs(direction.y);

                if (deltaX > deltaY)
                {
                    swipeDirection = (direction.x > 0) ? Direct.Right : Direct.Left;
                }
                else
                {
                    swipeDirection = (direction.y > 0) ? Direct.Forward : Direct.Backward;
                }
                _rotatePlayer();
                // tìm target
                PlayerMovement.instance._CheckWall();
            }
        }
    }

    private void _rotatePlayer()
    {
        if (swipeDirection == Direct.Forward)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (swipeDirection == Direct.Backward)
        {
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (swipeDirection == Direct.Left)
        {
            this.transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }
        else if (swipeDirection == Direct.Right)
        {
            this.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
    }
}
