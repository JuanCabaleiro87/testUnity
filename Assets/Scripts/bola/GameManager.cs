using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text points;
    private int aquiredPoints;

    public TMP_Text totalPoints;
    private int totalPointsNumber;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        aquiredPoints = 0;
        points.text = aquiredPoints.ToString();

        totalPointsNumber = transform.childCount;
        totalPoints.text = totalPointsNumber.ToString();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            nextLevel();
        }
    }

    public void addCollectible()
    {
        audioSource.Play();
        aquiredPoints++;
        points.text = aquiredPoints.ToString();
        

    }
    public void nextLevel()
    {
        Debug.Log("next level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
