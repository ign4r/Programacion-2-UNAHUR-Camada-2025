using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerPresenter : MonoBehaviour /// GESTIONA COMPONENTES, COLLISIONES
{
    private Rigidbody _rb;
    private PlayerModel _model;
    private PlayerInput _pInput;

    [SerializeField]
    private GameObject _mesh;
    public Action<bool> OnPlayerMoving { get; set; }
    public Action<int> OnCoinsCollected { get; set; }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _model = GetComponent<PlayerModel>();
        _pInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        /// _model.SetSpeed(40f*2); no valido
        
        //_model.SetPosition(transform.position);

        _model.OnCoinsChanged += PresenterCoinsChanged; //obtiene esa informacion del model
    }

    private void OnDisable()
    {
        _model.OnCoinsChanged -= PresenterCoinsChanged;

    }
    void FixedUpdate()
    {
        Vector3 input = _pInput.Axis;
        ApplyMovement(input);
        UpdateTilt(input.x);
    }

    public void ApplyMovement(Vector3 direction)
    {
        _rb.velocity = _model.CalculateMove(direction);

        bool isMoving = direction.magnitude > 0.1f;
        OnPlayerMoving?.Invoke(isMoving); ///SE DISPARA UN EVENTO PARA SABER SI SE ESTA MOVIENDO
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
    }
    private void PresenterCoinsChanged(int newCoinCount)
    {
        //luego dispara un evento, para exponer esa informacion
        OnCoinsCollected?.Invoke(newCoinCount);
    }
}
