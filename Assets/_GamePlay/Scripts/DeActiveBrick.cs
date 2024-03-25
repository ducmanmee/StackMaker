using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActiveBrick : MonoBehaviour
{
    [SerializeField] private GameObject groundUnBrick;
    [SerializeField] private BoxCollider boxGroundUnBrick;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(PlayerManager.instance.playerBrickList[PlayerManager.instance.playerBrickList.Count - 1]);
            PlayerManager.instance.playerBrickList.RemoveAt(PlayerManager.instance.playerBrickList.Count - 1);

            Vector3 temp = PlayerManager.instance.getTransformBody().position;
            temp.y -= .18f;
            PlayerManager.instance.setPositionBody(temp);

            groundUnBrick.SetActive(true);
            Destroy(boxGroundUnBrick);
        }
    }
}
