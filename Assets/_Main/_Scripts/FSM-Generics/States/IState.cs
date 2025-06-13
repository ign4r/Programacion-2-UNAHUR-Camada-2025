/// <summary>
/// Implementacion generica de un estado para una FSM.
/// Gestiona el ciclo de vida del estado y las transiciones basadas en entradas.
/// </summary>
/// <typeparam name="T">Tipo de entrada usada para las transiciones de estado.</typeparam>
public interface IState<T>
{
    T KeyState { get; }
    void Awake();
    void Execute();
    void Sleep();
    IState<T> GetTransition(T input);
    void AddTransition(T input, IState<T> nextState);
}