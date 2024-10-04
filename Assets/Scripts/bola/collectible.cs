using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    private GameManager gm;
    private void Start()
    {
            gm = FindAnyObjectByType<GameManager>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            gm.addCollectible();
            Destroy(gameObject);
            
        }
    }

}
