using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public List<GameObject> playerBrickList = new List<GameObject>();
    public GameObject playerBrick;
    [SerializeField] private Transform playerBody;

    private void makeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }

    private void Awake()
    {
        makeInstance();
    }

    public Transform getTransformBody() => playerBody.transform;
    public void setPositionBody(Vector3 temp)
    {
        playerBody.transform.position = temp;
    }
}
