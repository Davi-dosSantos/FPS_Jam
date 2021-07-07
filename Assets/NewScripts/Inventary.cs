using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    public RectTransform content;
    public List<GameObject> itens;
    
    void AddItem()
    {
        if(content.childCount < itens.Count)
        {
            GameObject item = Instantiate(itens[content.childCount], content.position, Quaternion.identity) as GameObject;
            item.transform.parent = content.transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       AddItem();
    }
}
