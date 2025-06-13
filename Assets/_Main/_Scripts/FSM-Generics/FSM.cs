/// <summary>
/// Una implementaci�n gen�rica de una m�quina de estados finitos (FSM).
/// Permite gestionar la transici�n entre diferentes estados basados en entradas y actualiza el estado actual.
/// </summary>
/// <typeparam name="T">Tipo de entrada que se usa para las transiciones entre estados.</typeparam>
public class FSM<T>
{
    private IState<T> _current; // Estado actual de la m�quina de estados - Creamos una interfaz generica..

    public IState<T> Current { get => _current; set => _current = value; }

    public FSM()
    {
    }

    /// <summary>
    /// Constructor que inicializa la m�quina de estados con un estado inicial.
    /// </summary>
    /// <param name="init">Estado inicial de la m�quina de estados.</param>
    public FSM(IState<T> init)
    {
        SetInit(init);
    }

    /// <summary>
    /// Establece el estado inicial y llama al m�todo Awake del estado.
    /// </summary>
    /// <param name="init">Estado inicial que se va a establecer.</param>
    public void SetInit(IState<T> init)
    {
        _current = init;  // Establece el estado actual.
        _current.Awake();  // Llama al m�todo Awake del estado inicial.
    }

    /// <summary>
    /// Actualiza el estado actual llamando a su m�todo Execute.
    /// Se debe llamar a este m�todo en cada ciclo de actualizaci�n del juego.
    /// </summary>
    public void OnUpdate()
    {
        if (_current != null)
            _current.Execute();  // Ejecuta la l�gica del estado actual.
    }

    /// <summary>
    /// Realiza una transici�n al siguiente estado basado en la entrada proporcionada.
    /// </summary>
    /// <param name="input">Entrada usada para determinar el nuevo estado.</param>
    public void Transitions(T input)
    {
        var newState = _current.GetTransition(input);
        if (newState == null || newState == _current) return; // No cambia si es el mismo

        _current.Sleep();
        _current = newState;
        _current.Awake();
    }
}