using UnityEngine;

public class ActionStateExample3<T> : BaseState<ExampleStatesEnum>
{
    public T StateTransition { get; set; }
    public MeteoriteModel Model { get; set; }
    public FSM<T> Fsm { get; set; }
    public override ExampleStatesEnum KeyState { get; protected set; }

    public ActionStateExample3(FSM<T> fsm, ExampleStatesEnum stateTransition, MeteoriteModel model = null)
    {
        KeyState = stateTransition;
        Fsm = fsm;
        Model = model;
    }

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
