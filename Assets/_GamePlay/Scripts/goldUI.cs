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
        pos = new Vector2(UIManager.Instance.getGoldTrans().position.x, UIManager.Instance.getGoldTrans().position.y) + Random.insideUnitCircle * 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDone)
        {
            swarmGold();
        }
        else
        {
            effectAnimGold();
        }    
    }

    private void swarmGold()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos, 100f * Time.deltaTime);
        if (Vector2.Distance(transform.position, pos) < 0.01f)
        {
            isDone = true;
        }
    }   
    private void effectAnimGold()
    {
        transform.position = Vector2.MoveTowards(transform.position, UIManager.Instance.getGoldPlayerTrans().position, 2000f * Time.deltaTime);
        if (Vector2.Distance(transform.position, UIManager.Instance.getGoldPlayerTrans().position) < 0.01f)
        {
            Destroy(gameObject);
        }
    }    
}
