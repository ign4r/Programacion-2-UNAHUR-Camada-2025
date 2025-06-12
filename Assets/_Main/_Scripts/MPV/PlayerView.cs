using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// Cambiar sprites, animaciones o materiales.
/// Mostrar o actualizar UI (TextMeshPro, Sliders, etc.).
/// Reproducir partículas, sonidos, efectos visuales.
/// Encender o apagar objetos visuales (como SetActive, Play(), Stop()).
/// Posiblemente exponer eventos de UI, como botones (OnClick), para que el presentador los maneje.
/// </summary>
public class PlayerView : MonoBehaviour ///Actualizamos UI, ejecutamos eventos visuales o sonoros
{
    //private PlayerPresenter playerPresenter;  Evitemos que la vista conozca al playerPresenter, no es lo ideal.
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private AudioSource coinSound;
    [SerializeField] private ParticleSystem _particleSystem;

    public void UpdateHealthText(float health)
    {
        healthText.text = "Life: " + health.ToString();
    }

    public void HandlePlayerMoving(bool value)
    {
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
