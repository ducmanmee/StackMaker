using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public static SwipeController.Direct direction = SwipeController.Direct.Null;
    public static PlayerMovement instance;
    private void makeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }

    private float raycastDistance = 10f;
    public LayerMask wallLayer;
    public float speedMove = 5f;

    public bool canMove = false;
    public Vector3 target;

    private void Awake()
    {
        makeInstance();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(canMove)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speedMove * Time.deltaTime);
        }
        if(Vector3.Distance(this.transform.position, target) < 0.001f)
        {
            canMove = false;
        }    
    }

    public void _CheckWall()
    {
        Vector3 rayPosition = transform.position;
        Vector3 rayForward = transform.forward;

     
        Ray ray = new Ray(rayPosition, rayForward);
        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit, raycastDistance, wallLayer))
        {
            if(SwipeController.instance.swipeDirection == SwipeController.Direct.Forward)
            {
                target = new Vector3(this.transform.position.x, this.transform.position.y, hit.collider.transform.position.z - 1f);
                
            }
            else if (SwipeController.instance.swipeDirection == SwipeController.Direct.Backward)
            {
                target = new Vector3(this.transform.position.x, this.transform.position.y, hit.collider.transform.position.z + 1f);
            }
            else if (SwipeController.instance.swipeDirection == SwipeController.Direct.Left)
            {
                target = new Vector3(hit.collider.transform.position.x + 1f, this.transform.position.y, this.transform.position.z);
            }
            else if (SwipeController.instance.swipeDirection == SwipeController.Direct.Right)
            {
                target = new Vector3(hit.collider.transform.position.x - 1f, this.transform.position.y, this.transform.position.z);
            }
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }    
}
