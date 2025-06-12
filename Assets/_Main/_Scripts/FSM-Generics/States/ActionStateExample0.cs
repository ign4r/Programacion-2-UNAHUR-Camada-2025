using UnityEngine;

public class ActionStateExample0<T> : BaseState<ExampleStatesEnum>
{
    private T _stateTransition;
    private MeteoriteModel _model;
    private FSM<T> _fsm;
    public ActionStateExample0(FSM<T> fsm, T stateTransition = default, MeteoriteModel model = null)
    {
        _stateTransition = stateTransition;
        _fsm = fsm;
        _model = model;
    }

    public override ExampleStatesEnum StateEnum => ExampleStatesEnum.Idle;

    public override void Awake()
    {
        Debug.Log("Idle State  Awake");
    }

    public override void Execute()
    {
        // Lógica mientras está en Idle
        Debug.Log("Idle State  Updating...");

        int timeRemaining = 10;

        if (timeRemaining < 1) 
        {
            //_fsm.Transitions(_stateTransition);
        }
    }

    public override void Sleep()
    {
        Debug.Log("Idle State 0 Sleep");
    }
}
