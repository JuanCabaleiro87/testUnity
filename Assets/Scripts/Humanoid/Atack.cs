using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    public BoxCollider fist;
        void Start()
    {
        DisableFistCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableFistCollider()
    {
        fist.enabled = true;
    }

    public void DisableFistCollider()
    {
        fist.enabled = false;
    }

}
