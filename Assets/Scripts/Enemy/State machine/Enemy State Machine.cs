using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _currentState;

    public State CurrentState { get; private set; }

    void Start()
    {
        _target = GetComponent<Enemy>().Target;
       Reset(_firstState);//вызываем для входа в первое состояние 
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();//если у текущего состояния сработал какой-то транзишен и можно перейти, то присвоим это следующее состояние сюда
        
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)//выходим из текущего состояния
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)//входим в новое состояние
            _currentState.Enter(_target);
    }
}