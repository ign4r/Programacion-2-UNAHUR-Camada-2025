using UnityEngine;

public class ActionStateExample2<T> : BaseState<ExampleStatesEnum>
{
    public T StateTransition { get; set; }
    public MeteoriteModel Model { get; set; }
    public FSM<T> Fsm { get; set; }
    public override ExampleStatesEnum KeyState { get; protected set; }

    public ActionStateExample2(FSM<T> fsm, ExampleStatesEnum stateTransition, MeteoriteModel model = null)
    {
        KeyState = stateTransition;
        Fsm = fsm;
        Model = model;
    }

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
