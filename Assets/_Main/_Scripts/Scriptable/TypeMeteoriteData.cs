using UnityEngine;
[CreateAssetMenu(fileName = "Type", menuName = "Actors/Type/Meteorite", order = 1)]
public class TypeMeteoriteData : ScriptableObject
{

    [SerializeField] private string descriptionData;
    [SerializeField] private int damageMeteorite;
    [SerializeField] private ParticleSystem particleMeteorite;
    [SerializeField] private AudioSource audioMeteorite;



    public string DescriptionData => descriptionData;
    public int Damage => damageMeteorite;
    public ParticleSystem ParticleMeteorite => particleMeteorite;
    public AudioSource AudioMeteorite => audioMeteorite;


}
