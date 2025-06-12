using System;
using UnityEditor.EditorTools;
using UnityEngine;

/// Presenter:
/// - Coordina input/sucesos (colisiones, ticks, eventos).
/// - Llama a métodos del Modelo.
/// - Observa el estado del Modelo.
/// - Actualiza la Vista (animaciones, efectos, etc.).
/// - Toma decisiones como destruir el GameObject

public class MeteoritePresenter : MonoBehaviour
{
    private MeteoriteModel _meteorModel;
    private MeteoriteView _meteorView;

    public event Action OnHitEvent;

    public int DamageMeteorite
    {
        get { return _meteorModel.MeteoriteData.Damage; }
    }

    private void Awake()
    {
        _meteorModel = GetComponent<MeteoriteModel>();
        _meteorView = GetComponent<MeteoriteView>();
     
    }
    private void OnEnable()
    {
  
        OnHitEvent += _meteorView.PlayExplosionEffect;
        OnHitEvent += _meteorModel.MarkAsDestroyed;

    }
    private void OnDisable()
    {
        OnHitEvent -= _meteorView.PlayExplosionEffect;
        OnHitEvent -= _meteorModel.MarkAsDestroyed;
    }
    public void OnHit()
    {
        OnHitEvent();
        PoolManager.Instance.ReturnObject(gameObject); 
    }

}
