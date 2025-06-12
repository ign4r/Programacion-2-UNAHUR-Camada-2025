/// <summary>
/// Una implementación genérica de una máquina de estados finitos (FSM).
/// Permite gestionar la transición entre diferentes estados basados en entradas y actualiza el estado actual.
/// </summary>
/// <typeparam name="T">Tipo de entrada que se usa para las transiciones entre estados.</typeparam>

public interface IState<T>
{
    T StateEnum { get; }
    void Awake();
    void Execute();
    void Sleep();
    IState<T> GetTransition(T input);
    void AddTransition(T input, IState<T> nextState);
}