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

    public int CurrentCoins { get; private set; }
    public float TiltSpeed { get => tiltSpeed; private set => tiltSpeed = value; }

    public event Action<int> OnCoinsChanged;
    public event Action<float> OnTakeDamage;
    public event Action<bool> OnMoving;

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
        //TODO: Logica de realizar el daño
        OnTakeDamage.Invoke(dmg);
    }
    public void AddCoin()
    {
        CurrentCoins++; //Logica

        OnCoinsChanged.Invoke(CurrentCoins);
    }


}
