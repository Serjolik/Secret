using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ContinuePressed()
    {
        Play();
    }

    public void NewGamePressed()
    {
        Play();
    }
    
    public void SettingsPressed()
    {

    }

    public void ExitPressed()
    {
        Application.Quit();
    }

}
