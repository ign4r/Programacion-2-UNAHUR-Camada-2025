using UnityEngine;
public enum ExampleStatesEnum
{
    Idle,
    Move,
    Dance,
    Attack
}

public class FSMController : MonoBehaviour
{
    private FSM<ExampleStatesEnum> _fsm;

    [field: SerializeField]
    public ExampleStatesEnum CurrentState { get; private set; }


    private void Start()
    {
        InitializeFSM();
    }

    private void Update()
    {
        _fsm.OnUpdate();
        CurrentState = _fsm.Current.KeyState;
    }

    private void InitializeFSM()
    {
        _fsm = new FSM<ExampleStatesEnum>();

        // Crear estados
        var idleState = new ActionStateExample0<ExampleStatesEnum>(_fsm,ExampleStatesEnum.Idle);
        var moveState = new ActionStateExample1<ExampleStatesEnum>(_fsm,ExampleStatesEnum.Move);
        var danceState = new ActionStateExample2<ExampleStatesEnum>(_fsm, ExampleStatesEnum.Dance);
        var attackState = new ActionStateExample3<ExampleStatesEnum>(_fsm, ExampleStatesEnum.Attack);

        // Configuraramos las transiciones
        idleState.AddTransition(ExampleStatesEnum.Move, moveState);
        idleState.AddTransition(ExampleStatesEnum.Dance, danceState);
        idleState.AddTransition(ExampleStatesEnum.Attack, attackState);

        moveState.AddTransition(ExampleStatesEnum.Idle, idleState);
        danceState.AddTransition(ExampleStatesEnum.Idle, idleState);
        attackState.AddTransition(ExampleStatesEnum.Idle, idleState);


        // Estado inicial
        _fsm.SetInit(idleState);
    }

    public void OnDanceEvent()
    {
        if (_fsm.Current.KeyState != ExampleStatesEnum.Dance)
            _fsm.Transitions(ExampleStatesEnum.Dance);
    }

    public void OnAttackEvent()
    {
        if (_fsm.Current.KeyState != ExampleStatesEnum.Attack)
            _fsm.Transitions(ExampleStatesEnum.Attack);
    }

    public void OnMoveEvent()
    {
        if (_fsm.Current.KeyState != ExampleStatesEnum.Move)
            _fsm.Transitions(ExampleStatesEnum.Move);
    }

    public void OnIdleEvent()
    {
        if (_fsm.Current.KeyState != ExampleStatesEnum.Idle)
            _fsm.Transitions(ExampleStatesEnum.Idle);
    }


}
