using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float hp = 100; // procent
    [SerializeField] private float speed = 2f;

    [SerializeField] private List<Vector3> pointsPositions;

    enum State
    {
        Attack,
        Moving,
        Search
    };
    State state;

    private void Update()
    {
        switch (state){
            case (State.Attack):
                AttackState();
                break;

            case (State.Moving):
                MovingState();
                break;

            case (State.Search):
                SearchState();
                break;

            default:
                break;
        }
    }

    private void AttackState()
    {

    }

    private void MovingState()
    {

    }

    private void SearchState()
    {

    }

}
