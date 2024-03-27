using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject curentLevel;
    public int numberOfLevel = 0;
    private void makeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }    
    }    
    [SerializeField] private GameObject[] levelMap;
    public   bool isWin;
    public bool canSwipe;


    private void Awake()
    {
        canSwipe = true;
        createMap(numberOfLevel);
        makeInstance();
        
    }

    public void createMap(int level)
    {
        Destroy(curentLevel);
        PlayerManager.instance.transform.position = Vector3.zero;
        PlayerManager.instance._changeAnim(Constant.IDLE);
        curentLevel = Instantiate(levelMap[level], this.transform.position, Quaternion.identity);
    }    

    public void winLevel(GameObject winVFX)
    {
        winVFX.SetActive(true);
        isWin = true;
        canSwipe = false;
        numberOfLevel += 1;
    }

    public IEnumerator openChest(GameObject chest_close, GameObject chest_open)
    {
        yield return new WaitForSeconds(4f);
        chest_close.gameObject.SetActive(false);
        chest_open.SetActive(true);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.nextLvPanel();
    }
}
