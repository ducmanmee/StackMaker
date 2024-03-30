using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject curentLevel;
    private int numberOfLevel = 0;

    private void makeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }    
    }    
    [SerializeField] private GameObject[] levelMap;
    public bool isWin;
    public bool canSwipe;

    private int goldWin;

    private bool isRestart;
    private bool isNextLevel;

    private void Awake()
    {
        canSwipe = true;
        createMap(numberOfLevel);
        //PlayerManager.instance.gameObject.SetActive(false);
        makeInstance();
        
    }

    public void createMap(int level)
    {
        Destroy(curentLevel);
        PlayerManager.instance.setPosition(Vector3.zero);
        PlayerManager.instance.setRotation(Vector3.zero);
        PlayerManager.instance.changeAnim(Constant.IDLE);
        curentLevel = Instantiate(levelMap[level], this.transform.position, Quaternion.identity);
        canSwipe = true;
        isNextLevel = true;
        isRestart = true;
    }    

    public void winLevel(GameObject winVFX)
    {
        winVFX.SetActive(true);
        isWin = true;
        canSwipe = false;
        goldWin = PlayerManager.instance.getBrickListCount();
    }

    public IEnumerator openChest(GameObject chestClose, GameObject chestOpen, bool isChest)
    {
        isChest = true;
        yield return new WaitForSeconds(4f);
        if (chestClose != null)
        {
            chestClose.SetActive(false);
        }

        if (chestOpen != null)
        {
            chestOpen.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        UIManager.Instance.activeNextLvPanel(isWin);
    }   

    public void restartLevel()
    {
        if(isRestart)
        {
            isRestart = false;
            StartCoroutine(restart());
        }    
    }    

    public void NextLevel()
    {
        if(isNextLevel)
        {
            isNextLevel= false;
            StartCoroutine(nextLevel());
        }
    }

    IEnumerator restart()
    {
        UIManager.Instance.goldUI(5); 
        yield return new WaitForSeconds(3f);
        isWin = false;
        StartCoroutine(UIMask.Instance.changeSizeMask());
        createMap(numberOfLevel);
        UIManager.Instance.activeNextLvPanel(isWin);
        CameraFollow.instance.setOriginalPos();
    }    

    IEnumerator nextLevel()
    {
        UIManager.Instance.goldUI(5);
        yield return new WaitForSeconds(3f);
        isWin = false;
        StartCoroutine(UIMask.Instance.changeSizeMask());
        numberOfLevel++;
        createMap(numberOfLevel);
        UIManager.Instance.activeNextLvPanel(isWin);
        CameraFollow.instance.setOriginalPos();
    }

    public int getGoldWin() => goldWin;
    
}
