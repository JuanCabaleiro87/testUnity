using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayBola()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayHumanoid()
    {
        SceneManager.LoadScene("Animations");
    }

    public void PlayParkour()
    {
        SceneManager.LoadScene("SecretLevel");
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    

}
