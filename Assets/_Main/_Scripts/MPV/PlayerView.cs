using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerView : MonoBehaviour ///Actualizamos UI, ejecutamos eventos visuales o sonoros
{
    private PlayerPresenter playerPresenter;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private AudioSource coinSound;
    [SerializeField] private ParticleSystem _particleSystem;
    public Action<bool> OnMovingView { get; set; }

    private void Awake()
    {
        playerPresenter = GetComponent<PlayerPresenter>();
    }
    private void OnEnable()
    {
    
        //y el view se suscribe a ese evento para cambiar la UI.
        //OnCoinsCollected: tiene informacion de tipo int es decir la cantidad actual de monedas
        playerPresenter.OnPlayerMoving += HandlePlayerMoving;
        playerPresenter.OnCoinsCollected += HandleCoinsCollected;
        playerPresenter.OnDamage += HandleDamageView;
    }

    private void OnDisable()
    {
        if (playerPresenter != null)
        {
            playerPresenter.OnCoinsCollected -= HandleCoinsCollected;
            playerPresenter.OnPlayerMoving -= HandlePlayerMoving;
        }
          
    }
    public void HandleDamageView(float dmg)
    {
        //Ejecuto animacion
        //Ejecuto particular
    }
    public void HandlePlayerMoving(bool value)
    {
        //
        
        Debug.Log("aca se deberian ejecutar las particulas");
        if (value)
        {
            _particleSystem.Play();
        }
        else
        {
            _particleSystem.Stop();
        }
       
    }
    public void HandleCoinsCollected(int newCoinCount) //cantidad actual de monedas
    {

        // Reproduce sonido si está asignado
        if (coinSound != null)
            coinSound.Play();

        // Actualiza el texto con la nueva cantidad de monedas
        coinsText.text = newCoinCount.ToString();


    }
}
