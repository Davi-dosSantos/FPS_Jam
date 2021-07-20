using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaçãoAttack : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    
}
