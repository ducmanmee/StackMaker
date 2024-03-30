using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class CutOutMaskUI : Image
{
    [SerializeField] private RectTransform trans;
    private Vector2 wh;
    public override Material materialForRendering 
    {
        get
        {
            Material material = new Material(base.materialForRendering);
            material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
            return material;
        }
        
    }

    protected override void Awake()
    {
        wh = new Vector2(trans.rect.width, trans.rect.height);

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            wh = Vector2.Lerp(Vector2.zero, new Vector2(1000f, 1000f), 0.7f);
        }
        trans.sizeDelta = wh;
    }
}
