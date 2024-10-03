using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text points;
    private int aquiredPoints;
    // Start is called before the first frame update
    void Start()
    {
       aquiredPoints = 0;
       points.text = aquiredPoints.ToString();
    }

    // Update is called once per frame

    public void addCollectible()
    {
        aquiredPoints++;
        points.text = aquiredPoints.ToString();

    }
}
