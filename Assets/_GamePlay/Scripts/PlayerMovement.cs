using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public static SwipeController.Direct direction = SwipeController.Direct.Null;
    public static PlayerMovement instance;
    private void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }

    private float raycastDistance = 100f;
    public LayerMask wallLayer;
    public float speedMove = 5f;

    public bool canMove = false;
    public Vector3 target;

    private void Awake()
    {
        MakeInstance();
    }

    void Update()
    {
        if(canMove)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speedMove * Time.deltaTime);
        }   

        if(Vector3.Distance(this.transform.position, target) < 0.01f)
        {
            canMove = false;
            PlayerManager.instance.ChangeAnim(Constant.IDLE);
        }    
    }

    public void CheckWall()
    {
        Vector3 rayPosition = transform.position;
        Vector3 rayForward = transform.forward;

     
        Ray ray = new Ray(rayPosition, rayForward);
        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit, raycastDistance, wallLayer))
        {
            Debug.DrawRay(rayPosition, rayForward * raycastDistance, Color.red);
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
