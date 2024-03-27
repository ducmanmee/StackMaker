using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        makeInstance();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void nextLvPanel()
    {
        nextLevelPanel.SetActive(true);
    }    
}
