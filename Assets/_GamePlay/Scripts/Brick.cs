using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{     
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Vector3 temp = PlayerManager.instance.getTransformBody().position;
            temp.y += .18f;
            PlayerManager.instance.setPositionBody(temp);
            GameObject _playerBrick = Instantiate(PlayerManager.instance.playerBrick, other.transform.position, Quaternion.Euler(other.transform.rotation.x - 90f, PlayerManager.instance.getTransformBody().transform.rotation.y, other.transform.rotation.z));
            _playerBrick.transform.SetParent(PlayerManager.instance.getTransformBody());
            _playerBrick.transform.localScale = new Vector3(PlayerManager.instance.getTransformBody().localScale.x, PlayerManager.instance.getTransformBody().localScale.y, PlayerManager.instance.getTransformBody().localScale.z - .5f);

            PlayerManager.instance.playerBrickList.Add(_playerBrick);
        }
    }
}
