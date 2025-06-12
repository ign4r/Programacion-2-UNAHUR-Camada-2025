using UnityEngine;

/// Model:
/// Tiene estado mutable(vida actual, cooldowns, etc.).
///Aplica l�gica.
/// Usa el ScriptableObject como configuraci�n base.

public class MeteoriteModel : MonoBehaviour
{
    [SerializeField]
    private TypeMeteoriteData _meteoriteData;

    public TypeMeteoriteData MeteoriteData { get => _meteoriteData; }
    public bool IsDestroyed { get; private set; }

    public float TimeAlive { get; private set; }

    private void Start()
    {
        IsDestroyed = false;
        TimeAlive = 0f;
    }
    private void Update()
    {
        TimeAlive += Time.deltaTime;
    }

    public void MarkAsDestroyed()
    {
        IsDestroyed = true;
    }




}

