using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldUI : MonoBehaviour
{
    private Vector2 pos;
    private bool isDone;
    // Start is called before the first frame update
    void Awake()
    {
        isDone = false;
        pos = new Vector2(UIManager.Instance.GetGoldTrans().position.x, UIManager.Instance.GetGoldTrans().position.y) + Random.insideUnitCircle * 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDone)
        {
            SwarmGold();
        }
        else
        {
            EffectAnimGold();
        }    
    }

    private void SwarmGold()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos, 100f * Time.deltaTime);
        if (Vector2.Distance(transform.position, pos) < 0.01f)
        {
            isDone = true;
        }
    }   
    private void EffectAnimGold()
    {
        transform.position = Vector2.MoveTowards(transform.position, UIManager.Instance.GetGoldPlayerTrans().position, 2000f * Time.deltaTime);
        if (Vector2.Distance(transform.position, UIManager.Instance.GetGoldPlayerTrans().position) < 0.01f)
        {
            Destroy(gameObject);
        }
    }    
}
