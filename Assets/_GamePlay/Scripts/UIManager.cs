using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void MakeInstance()
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
        MakeInstance();
        isSwarm = false;
    }

    public void ActiveNextLvPanel(bool isWin)
    {
        UpdateGoldText(bonusGoldText, GameManager.Instance.GetGoldWin());
        nextLevelPanel.SetActive(isWin);  
    }
    public void GoldUI(int count)
    {
        isSwarm = true;
        for (int i = 0; i < count; i++)
        {
            Instantiate(gold, goldTransform.position, Quaternion.identity, goldTransform);
        }    
        StartCoroutine(IncreaseToTargetGold(2f));
    }  

    public Transform GetGoldTrans() => goldTransform;
    public Transform GetGoldPlayerTrans() => goldPlayerTransform;

    IEnumerator IncreaseToTargetGold(float duration)
    {
        float time = 0f;
        currentGold = int.Parse(goldText.text);
        targetGold = currentGold + GameManager.Instance.GetGoldWin();
        while ( time < duration)
        {
            currentGold = (int)Mathf.Lerp(currentGold, targetGold, time / duration);
            UpdateGoldText(goldText, currentGold);
            time += Time.deltaTime;
            yield return null;
        }    
        currentGold = targetGold; 
        UpdateGoldText(goldText, currentGold);
    }    

    private void UpdateGoldText(Text updateText ,int value)
    {
        updateText.text = value.ToString();
    }

}