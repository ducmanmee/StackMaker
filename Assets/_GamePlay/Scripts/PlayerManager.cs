using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public List<GameObject> playerBrickList = new List<GameObject>();
    [SerializeField] private Transform playerBody;
    public GameObject playerBrick;
    public Rigidbody rb_player;
    public Animator anim;
    private string currentAnim;
    public AudioSource audioSource;
    public AudioClip swipeClip;

    private void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }

    private void Awake()
    {
        MakeInstance();
    }

    public void SetPosition(Vector3 temp)
    {
        this.transform.position = temp;
    }
    public void SetRotation(Vector3 temp)
    {
        this.transform.eulerAngles = temp;
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
    public void AddBrick()
    {
        Vector3 temp = playerBody.transform.position;
        temp.y += .18f;
        playerBody.transform.position = temp;
        GameObject newPlayerBrick = Instantiate(playerBrick, playerBody.position, Quaternion.Euler(transform.rotation.x - 90f, transform.rotation.y, transform.rotation.z), this.transform);
        ChangeAnim(Constant.TAKEBRICK);
        playerBrickList.Add(newPlayerBrick);
    }

    public void UnBrick(GameObject groundUnBrick, BoxCollider boxGroundUnBrick)
    {
        Destroy(playerBrickList[playerBrickList.Count - 1]);
        playerBrickList.RemoveAt(playerBrickList.Count - 1);
        Vector3 temp = playerBody.transform.position;
        temp.y -= .18f;
        playerBody.transform.position = temp;
        groundUnBrick.SetActive(true);
    }
    
    public int GetBrickListCount()
    {
        return playerBrickList.Count;
    }    
}
