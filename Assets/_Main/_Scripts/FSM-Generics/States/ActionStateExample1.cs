using UnityEngine;

public class ActionStateExample1<T> : BaseState<ExampleStatesEnum>
{
    private T _stateTransition;
    private MeteoriteModel _model;
    private FSM<T> _fsm;
    public ActionStateExample1(FSM<T> fsm, T stateTransition = default, MeteoriteModel model = null)
    {
        _stateTransition = stateTransition;
        _fsm = fsm;
        _model = model;
    }
    public override ExampleStatesEnum StateEnum => ExampleStatesEnum.Move;

    public override void Awake()
    {
        Debug.Log("Move State Awake");
    }

    public override void Execute()
    {
        // Lógica mientras está en Idle
        Debug.Log("Move State Updating...");

  
    }

    public override void Sleep()
    {
        Debug.Log("Move State Sleep");
    }
}
