using UnityEngine;

public class PlayStateManager : MonoBehaviour
{
    PlayerMovement playerMovement;

    enum GameState
    {
        Play,
        Cutscene,
        Interact,
        Settings,
        GameOver
    };

    private GameState currentState;

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
                currentState = GameState.Play;
                break;
            case GameState.Cutscene:
                playerMovement.CanMoveChanging(false);
                currentState = GameState.Cutscene;
                break;
            case GameState.Interact:
                playerMovement.CanMoveChanging(false);
                currentState = GameState.Interact;
                break;
            case GameState.Settings:
                playerMovement.CanMoveChanging(false);
                currentState = GameState.Settings;
                break;
            case GameState.GameOver:
                playerMovement.CanMoveChanging(false);
                currentState = GameState.GameOver;
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

    public void Interact()
    {
        ChangeState(GameState.Interact);
        Debug.Log("Interact");
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

    public bool isFree()
    {
        if (currentState == GameState.Play)
        {
            return true;
        }

        return false;
    }

    public bool inPause()
    {
        if (currentState == GameState.Settings)
        {
            return true;
        }

        return false;
    }

}
