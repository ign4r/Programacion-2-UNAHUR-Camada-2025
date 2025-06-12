using System;
using UnityEngine;
/// <summary>
/// Tiene estado mutable(vida actual, cooldowns, etc.).
/// Aplica lógica.
/// Usa el ScriptableObject como configuración base.
/// </summary>
public class PlayerModel : MonoBehaviour, IDamageable ///Calculos, datos, lo mas abstracto posible.
{
    [SerializeField]
    private Quaternion initTiltRotation;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float tiltAngle = 30f; // cuanto inclina la nave

    [SerializeField]
    private float tiltSpeed = 5f;  // que tan rapido se inclina

    [SerializeField]
    private float maxHealth = 100f;

    private float currentHealth; // o el valor máximo que tengas

    public int CurrentCoins { get; private set; }
    public float TiltSpeed { get => tiltSpeed; private set => tiltSpeed = value; }

    public event Action<int> OnCoinsChanged;
    public event Action<float> OnTakeDamage;
    public event Action<bool> OnMoving;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public Vector3 CalculateMove(Vector3 direction)
    {
        return direction.normalized * moveSpeed;
    }
    public Quaternion CalculateTargetRotation(float inputX)
    {
        float tiltZ = 0f;
        if (Mathf.Abs(inputX) > 0.01f)
            tiltZ = -inputX * tiltAngle;

        return initTiltRotation * Quaternion.Euler(0f, 0f, tiltZ);
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;               // Reducís la vida actual
        currentHealth = Mathf.Max(0, currentHealth); // Clamp para no bajar de 0

        OnTakeDamage?.Invoke(currentHealth); // Invocás evento con vida actual
    }
    public void AddCoin()
    {
        CurrentCoins++; //Logica

        OnCoinsChanged.Invoke(CurrentCoins);
    }


}
