using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStateManager : MonoBehaviour
{
    PlayerMovement playerMovement;

    enum GameState
    {
        Play,
        Cutscene,
        Settings,
        GameOver
    };

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.Play:
                playerMovement.CanMoveChanging(true);
                break;
            case GameState.Cutscene:
                playerMovement.CanMoveChanging(false);
                break;
            case GameState.Settings:
                playerMovement.CanMoveChanging(false);
                break;
            case GameState.GameOver:
                playerMovement.CanMoveChanging(false);
                break;
        }
    }

    public void Play()
    {
        ChangeState(GameState.Play);
        Debug.Log("Play");
    }

    public void Settings()
    {
        ChangeState(GameState.Settings);
        Debug.Log("Settings");
    }

    public void Cutscene()
    {
        ChangeState(GameState.Cutscene);
        Debug.Log("Cutscene");
    }

    public void Dialog()
    {
        ChangeState(GameState.Cutscene);
        Debug.Log("Dialog");
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
        Debug.Log("GameOver");
    }

}
