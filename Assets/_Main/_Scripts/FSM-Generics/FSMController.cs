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

    private void Start()
    {
        InitializeFSM();
    }

    private void Update()
    {
        _fsm.OnUpdate();

        var currentStateEnum = _fsm.Current.StateEnum; // obtengo el enum del estado actual

        ExampleStatesEnum nextStateEnum = ChoseStateForCondition();

        if (!nextStateEnum.Equals(currentStateEnum)) // si el estado a transicionar no es igual al actual, realiza la transicion
        {
            _fsm.Transitions(nextStateEnum); //transicionamos
        }
    }

    private void InitializeFSM()
    {
        _fsm = new FSM<ExampleStatesEnum>();

        // Crear estados
        var idleState = new ActionStateExample0<ExampleStatesEnum>(_fsm);
        var moveState = new ActionStateExample1<ExampleStatesEnum>(_fsm);
        var danceState = new ActionStateExample2<ExampleStatesEnum>(_fsm);
        var attackState = new ActionStateExample3<ExampleStatesEnum>(_fsm);

        // Configurar transiciones
        idleState.AddTransition(ExampleStatesEnum.Move, moveState);
        idleState.AddTransition(ExampleStatesEnum.Dance, danceState);
        idleState.AddTransition(ExampleStatesEnum.Attack, attackState);

        moveState.AddTransition(ExampleStatesEnum.Idle, idleState);


        // Estado inicial
        _fsm.SetInit(idleState);
    }


    private ExampleStatesEnum ChoseStateForCondition()
    {
        if (IsDance())
            return ExampleStatesEnum.Dance;

        if (ShouldAttack())
            return ExampleStatesEnum.Attack;

        if (ShouldMove())
            return ExampleStatesEnum.Move;

        return ExampleStatesEnum.Idle; 
    }

    private bool IsDance()
    {
        return Input.GetKey(KeyCode.D); // Condicion, se puede adaptar para una IA
    }

    private bool ShouldAttack()
    {
        return Input.GetKeyDown(KeyCode.A); // Condicion, se puede adaptar para una IA
    }

    private bool ShouldMove()
    {
        return Input.GetKey(KeyCode.M); // Condicion, se puede adaptar para una IA
    }
}
