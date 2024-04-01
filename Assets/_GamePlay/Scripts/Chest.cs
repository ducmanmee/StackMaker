using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isChest;
    private GameObject chestClose;
    [SerializeField] private GameObject chestOpen;
    private void Awake()
    {
        isChest = false;
        chestClose = this.gameObject;
    }
    private void Update()
    {
        if (Vector3.Distance(PlayerManager.instance.transform.position, this.transform.position) < 2f)
        {
            PlayerMovement.instance.canMove = false;
            PlayerManager.instance.ChangeAnim(Constant.WIN);
            if(!isChest)
            {
                GameManager.Instance.StartCoroutine(GameManager.Instance.OpenChest(chestClose, chestOpen, isChest));
            }
        }
    }
}
