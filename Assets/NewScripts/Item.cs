using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public int id, indice;
    public string Nome;
    public Texture2D Imagem;
    public GameObject Objeto;

    public int Qnt_max, Qnt_atual;
    public bool Destruivel;
    
    // Start is called before the first frame update

    void NomeItem()
    {
        transform.GetChild(0).GetComponent<Text>().text = Nome;
    }

    void QntItem()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Qnt_atual + "";
    }
    
    
    void Start()
    {
        NomeItem();
        QntItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
