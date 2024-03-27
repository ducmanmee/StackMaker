using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isChest;
    private GameObject chest_close;
    [SerializeField] private GameObject chest_open;
    private void Awake()
    {
        isChest = false;
        chest_close = this.gameObject;
    }
    private void Update()
    {
        if (Vector3.Distance(PlayerManager.instance.transform.position, this.transform.position) < 2.1f)
        {
            PlayerMovement.instance.canMove = false;
            PlayerManager.instance._changeAnim(Constant.WIN);
            if(!isChest)
            {
                GameManager.Instance.StartCoroutine(GameManager.Instance.openChest(chest_close, chest_open));
            }    

        }
    }
}
