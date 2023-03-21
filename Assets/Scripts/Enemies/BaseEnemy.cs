using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Enemy params:")]
    [SerializeField] private float hp = 100; // procent
    [SerializeField] private float damage = 3;
    [SerializeField] private float speed = 2f;

    [Header("Points positions")]
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

    private void CheckCurrentPosition()
    {
        int nearestPointId;
        float minDistance = 10000;
        int index = 0;
        foreach(Vector3 position in pointsPositions)
        {
            float localDistance = Vector3.Distance(transform.position, position);

            if (localDistance < minDistance)
            {
                minDistance = localDistance;
                nearestPointId = index;
            }

            index++;
        }
    }

    private void ChangeState(State newState)
    {
        state = newState;
        CheckCurrentPosition();
    }

}
