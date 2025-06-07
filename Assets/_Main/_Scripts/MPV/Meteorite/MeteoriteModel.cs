using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteModel : MonoBehaviour,IDamageable
{
    [SerializeField]
    private MeteoriteDataObject _meteoriteData;

    public MeteoriteDataObject MeteoriteData { get => _meteoriteData; }

    public void TakeDamage(float dmg)
    {
        //Logica de daño
        // Invocar evento de OnDamage
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
