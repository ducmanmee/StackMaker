using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMask : MonoBehaviour
{
    public static UIMask Instance;

    public RectTransform rectTransform;

    public float targetWidth = 1100f;
    public float targetHeight = 2000f;
    public float changeSpeed = 1f;
    private bool isDone;
    private bool increasing;
    private float newWidth;
    private float newHeight;

    private void makeInstance()
    {
        if(Instance == null)
        {
            Instance = this;
        }    
    }

    private void Awake()
    {
        makeInstance();
    }

    public IEnumerator changeSizeMask()
    {
        increasing = false;
        isDone = false;
        while(!isDone)
        {
            if (!increasing)
            {
                newWidth = Mathf.Lerp(rectTransform.sizeDelta.x, 0, Time.deltaTime * changeSpeed);
                newHeight = Mathf.Lerp(rectTransform.sizeDelta.y, 0, Time.deltaTime * changeSpeed);

                if (newWidth <= 10f && newHeight <= 10f)
                {
                    increasing = true;
                }
            }
            else
            {
                newWidth = Mathf.Lerp(rectTransform.sizeDelta.x, targetWidth + 10f, Time.deltaTime * changeSpeed);
                newHeight = Mathf.Lerp(rectTransform.sizeDelta.y, targetHeight + 10f, Time.deltaTime * changeSpeed);

                if (newWidth >= targetWidth && newHeight >= targetHeight)
                {
                    isDone = true;
                }
            }

            rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
            yield return null;
        }    
    }    
}
