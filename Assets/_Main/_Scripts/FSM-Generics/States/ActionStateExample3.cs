using UnityEngine;

public class ActionStateExample3<T> : BaseState<ExampleStatesEnum>
{
    private T _stateTransition;
    private MeteoriteModel _model;
    private FSM<T> _fsm;
    public ActionStateExample3(FSM<T> fsm, T stateTransition = default, MeteoriteModel model = null)
    {
        _stateTransition = stateTransition;
        _fsm = fsm;
        _model = model;
    }

    public override ExampleStatesEnum StateEnum => ExampleStatesEnum.Attack;
    public override void Awake()
    {
        Debug.Log("Attack State Awake");
    }

    public override void Execute()
    {
        // Lógica mientras está en Idle
        Debug.Log("Attack State Updating...");


    }

    public override void Sleep()
    {
        Debug.Log("Attack State Sleep");
    }
}
