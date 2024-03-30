using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void makeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }    
    }    
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private Text goldText;
    [SerializeField] private Text bonusGoldText;
    [SerializeField] private GameObject gold;
    [SerializeField] private Transform goldTransform;
    [SerializeField] private Transform goldPlayerTransform;

    private bool isSwarm;
    private int currentGold = 0;
    private int targetGold = 0;
    private float duration;

    private void Awake()
    {
        makeInstance();
        isSwarm = false;
    }

    public void activeNextLvPanel(bool isWin)
    {
        updateGoldText(bonusGoldText, GameManager.Instance.getGoldWin());
        nextLevelPanel.SetActive(isWin);  
    }
    public void goldUI(int count)
    {
        isSwarm = true;
        for (int i = 0; i < count; i++)
        {
            Instantiate(gold, goldTransform.position, Quaternion.identity, goldTransform);
        }    
        StartCoroutine(increaseToTargetGold(2f));
    }  

    public Transform getGoldTrans() => goldTransform;
    public Transform getGoldPlayerTrans() => goldPlayerTransform;

    IEnumerator increaseToTargetGold(float duration)
    {
        float time = 0f;
        currentGold = int.Parse(goldText.text);
        targetGold = currentGold + GameManager.Instance.getGoldWin();
        while ( time < duration)
        {
            currentGold = (int)Mathf.Lerp(currentGold, targetGold, time / duration);
            updateGoldText(goldText, currentGold);
            time += Time.deltaTime;
            yield return null;
        }    
        currentGold = targetGold; 
        updateGoldText(goldText, currentGold);
    }    

    private void updateGoldText(Text updateText ,int value)
    {
        updateText.text = value.ToString();
    }

}