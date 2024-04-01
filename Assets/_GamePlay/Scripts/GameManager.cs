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

    private void MakeInstance()
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
        CreateMap(numberOfLevel);
        //PlayerManager.instance.gameObject.SetActive(false);
        MakeInstance();
        
    }

    public void CreateMap(int level)
    {
        Destroy(curentLevel);
        PlayerManager.instance.SetPosition(Vector3.zero);
        PlayerManager.instance.SetRotation(Vector3.zero);
        PlayerManager.instance.ChangeAnim(Constant.IDLE);
        curentLevel = Instantiate(levelMap[level], this.transform.position, Quaternion.identity);
        canSwipe = true;
        isNextLevel = true;
        isRestart = true;
    }    

    public void WinLevel(GameObject winVFX)
    {
        winVFX.SetActive(true);
        isWin = true;
        canSwipe = false;
        goldWin = PlayerManager.instance.GetBrickListCount();
    }

    public IEnumerator OpenChest(GameObject chestClose, GameObject chestOpen, bool isChest)
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
        UIManager.Instance.ActiveNextLvPanel(isWin);
    }   

    public void RestartLevel()
    {
        if(isRestart)
        {
            isRestart = false;
            StartCoroutine(IERestart());
        }    
    }    

    public void NextLevel()
    {
        if(isNextLevel)
        {
            isNextLevel= false;
            StartCoroutine(IENextLevel());
        }
    }

    IEnumerator IERestart()
    {
        UIManager.Instance.GoldUI(5); 
        yield return new WaitForSeconds(3f);
        isWin = false;
        StartCoroutine(UIMask.Instance.ChangeSizeMask());
        CreateMap(numberOfLevel);
        UIManager.Instance.ActiveNextLvPanel(isWin);
        CameraFollow.instance.SetOriginalPos();
    }    

    IEnumerator IENextLevel()
    {
        UIManager.Instance.GoldUI(5);
        yield return new WaitForSeconds(3f);
        isWin = false;
        StartCoroutine(UIMask.Instance.ChangeSizeMask());
        numberOfLevel++;
        CreateMap(numberOfLevel);
        UIManager.Instance.ActiveNextLvPanel(isWin);
        CameraFollow.instance.SetOriginalPos();
    }

    public int GetGoldWin() => goldWin;
    
}
