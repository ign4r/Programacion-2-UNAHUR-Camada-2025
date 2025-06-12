using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
///Coordina input/sucesos (colisiones, ticks, eventos).
///Llama a métodos del Modelo.
///Observa el estado del Modelo.
///Actualiza la Vista (animaciones, efectos, etc.).
///Toma decisiones como destruir el GameObject.
/// Es el unico que conoce al modelo y la vista.
///</summary>


[RequireComponent(typeof(Rigidbody))]
public class PlayerPresenter : MonoBehaviour 
{
    private Rigidbody _rb;
    private PlayerModel _model;
    private PlayerView _view;
    private PlayerInput _pInput;

    [SerializeField]
    private GameObject _mesh;
    public Action<bool> OnPlayerMoving { get; set; } 


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _model = GetComponent<PlayerModel>();
        _pInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        //_model.OnTakeDamage += _view.UpdateHealthText; 
        //_model.OnCoinsChanged += _view.HandleCoinsCollected;
        //OnPlayerMoving += _view.HandlePlayerMoving;
        
    }
    private void OnDisable()
    {
        //_model.OnTakeDamage -= _view.UpdateHealthText;
        //_model.OnCoinsChanged -= _view.HandleCoinsCollected;

    }

 
    void FixedUpdate()
    {
        Vector3 input = _pInput.Axis;
        ApplyMovement(input);
        UpdateTilt(input.x);
    }

    public void ApplyMovement(Vector3 direction)
    {
        Vector3 velocity = _model.CalculateMove(direction);
        _rb.velocity = velocity;
        bool isMoving = velocity.magnitude > 0.1f;

        OnPlayerMoving?.Invoke(isMoving);  // opcion 1 comunicarse con eventos con la vista.

        //_view.HandlePlayerMoving(isMoving); // opcion 2 llamada directa a la vista

    }

    // Metodo para actualizar la inclinación del mesh
    private void UpdateTilt(float inputX)
    {
        Quaternion targetRotation = _model.CalculateTargetRotation(inputX);
        Quaternion currentRotation = _mesh.transform.localRotation;
        _mesh.transform.localRotation = Quaternion.Slerp(currentRotation, targetRotation, _model.TiltSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _model.AddCoin();
            Destroy(other.gameObject);
   
        }

        if (other.CompareTag("Meteorite"))
        {
            var meteorite = other.GetComponent<MeteoritePresenter>();
            //int damage = meteorite.DamageMeteorite;

            //_model.TakeDamage(damage); // El player se daña

            meteorite.OnHit(); // Le avisa al meteorito que fue impactado

        }
    }

}
