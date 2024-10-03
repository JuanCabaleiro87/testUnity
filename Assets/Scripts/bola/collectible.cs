using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().addCollectible();
            Destroy(gameObject);
        }
    }

}
