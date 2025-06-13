using UnityEngine;

public class ActionStateExample0<T> : BaseState<T>
{
    public T StateTransition { get ; set; }
    public MeteoriteModel Model { get; set; }
    public FSM<T> Fsm { get ; set ; }
    public override T KeyState { get; protected set; }

    public ActionStateExample0(FSM<T> fsm, T keyState, MeteoriteModel model = null)
    {
        KeyState = keyState;
        Fsm = fsm;
        Model = model;
    }

    public override void Awake()
    {
        Debug.Log("Idle State  Awake");
   
    }

    public override void Execute()
    {
        // Lógica mientras está en Idle
        Debug.Log("Idle State  Updating...");

        // OPCIONAL: podemos crear un tiempo de duracion de el estado.

        int timeRemaining = 10; 

        if (timeRemaining < 1) 
        {
            ///_fsm.Transitions(_stateTransition);
        }
    }

    public override void Sleep()
    {
        Debug.Log("Idle State 0 Sleep");

    }
}
