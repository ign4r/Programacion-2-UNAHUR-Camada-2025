using UnityEngine;

public class ActionStateExample2<T> : BaseState<ExampleStatesEnum>
{
    private T _stateTransition;
    private MeteoriteModel _model;
    private FSM<T> _fsm;
    public ActionStateExample2(FSM<T> fsm, T stateTransition = default, MeteoriteModel model = null)
    {
        _stateTransition = stateTransition;
        _fsm = fsm;
        _model = model;
    }

    public override ExampleStatesEnum StateEnum => ExampleStatesEnum.Dance;
    public override void Awake()
    {
        Debug.Log("Dance State Awake");
    }

    public override void Execute()
    {
        // Lógica mientras está en Idle
        Debug.Log("Dance State Updating...");

   
    }

    public override void Sleep()
    {
        Debug.Log("Dance State Sleep");
    }
}
