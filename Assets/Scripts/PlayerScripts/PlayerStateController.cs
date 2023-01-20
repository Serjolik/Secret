using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    enum PlayerState
    {
        None,
        Stay,
        Walk,
        Run,
        Cutscene,
        Reading,
        Pause
    }
    private PlayerState playerState = PlayerState.None;

    void Update()
    {
        switch (playerState)
        {
            case PlayerState.Stay:
                break;
            case PlayerState.Walk:
                break;
            case PlayerState.Run:
                break;
            case PlayerState.Cutscene:
                break;
            case PlayerState.Reading:
                break;
            case PlayerState.Pause:
                break;

        }
    }

}
