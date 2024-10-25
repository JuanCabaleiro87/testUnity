using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public int hp;
    public int dañoPuño;
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
            hp -= dañoPuño;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
