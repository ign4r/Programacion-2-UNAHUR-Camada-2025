using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///La View se encarga de:
///Mostrar animaciones.
///Activar efectos visuales.
///Reproducir sonidos.
///Cambiar sprites, colores, partículas, etc.
///No toma decisiones lógicas, solo muestra lo que el Presenter le indica.
//Los nombres de métodos en una View deben reflejar acciones visuales o auditivas, no lógica del juego

public class MeteoriteView : MonoBehaviour
{

    [SerializeField] private ParticleSystem explosionFX;
    [SerializeField] private AudioSource explosionSFX;
    [SerializeField] private MeshRenderer meshRenderer;

    public void PlayExplosionEffect()
    {
        if (explosionFX != null)
            explosionFX.Play();

        if (explosionSFX != null)
            explosionSFX.Play();
    }

}
