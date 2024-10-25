using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public int hp;
    public int da�oPu�o;
    public Animator anim;
           
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "golpeImpacto")
        {
            if (anim != null)
            {
                anim.Play("DummyGetImpact");
            }
            hp -= da�oPu�o;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
