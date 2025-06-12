using System.Collections.Generic;

/// <summary>
/// Clase base abstracta para estados en una maquina de estados finitos (FSM) generica.
/// Esta clase provee la implementacion comun para manejar transiciones entre estados,
/// almacenando las posibles transiciones en un diccionario que relaciona entradas (inputs) con estados siguientes.
/// 
/// Las subclases deben implementar los metodos Awake, Execute y Sleep para definir el comportamiento especifico de cada estado.
/// </summary>
/// <typeparam name="T">Tipo de dato usado para las entradas que determinan las transiciones entre estados.</typeparam>
public abstract class BaseState<T> : IState<T>
{
    private Dictionary<T, IState<T>> _transitions = new();

    public abstract T StateEnum { get; }

    /// <summary>
    /// Metodo que se llama cuando el estado se activa.
    /// </summary>
    public abstract void Awake();

    /// <summary>
    /// Metodo que contiene la logica que se ejecuta en cada actualizacion mientras el estado esta activo.
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// Metodo que se llama cuando el estado se desactiva o se abandona.
    /// </summary>
    public abstract void Sleep();

    /// <summary>
    /// Agrega una transicion desde este estado hacia otro, basada en la entrada dada.
    /// </summary>
    /// <param name="input">Entrada que provoca la transicion.</param>
    /// <param name="nextState">Estado al que se transita.</param>
    public void AddTransition(T input, IState<T> nextState)
    {
        if (!_transitions.ContainsKey(input))
            _transitions.Add(input, nextState);
    }

    /// <summary>
    /// Obtiene el siguiente estado al que se debe transitar segun la entrada recibida.
    /// Si no existe una transicion para la entrada, devuelve el mismo estado actual (se queda).
    /// </summary>
    /// <param name="input">Entrada que determina la transicion.</param>
    /// <returns>Estado siguiente o el mismo estado actual si no hay transicion.</returns>
    public IState<T> GetTransition(T input)
    {
        if (_transitions.TryGetValue(input, out IState<T> nextState))
            return nextState;
        return this; // Si no hay transicion, quedarse en el mismo estado
    }
}
