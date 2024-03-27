using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActiveBrick : MonoBehaviour
{
    [SerializeField] private GameObject groundUnBrick;
    [SerializeField] private BoxCollider boxGroundUnBrick;
    private bool isActiveBrick;
    private void Awake()
    {
        isActiveBrick = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(isActiveBrick)
            {
                if(PlayerManager.instance.playerBrickList.Count > 0)
                {
                    isActiveBrick = false;
                    this.gameObject.SetActive(false);
                    PlayerManager.instance.unBrick(groundUnBrick, boxGroundUnBrick);
                }
                else
                {
                    PlayerMovement.instance.canMove = false;
                    PlayerManager.instance._changeAnim(Constant.WIN);
                }    
            }
        }
    }
}
