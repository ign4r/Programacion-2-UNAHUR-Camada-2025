using UnityEngine;
[CreateAssetMenu(fileName = "Actors", menuName = "Actors/Meteorite", order = 1)]
public class MeteoriteDataObject : ScriptableObject
{

    [SerializeField] private string descriptionData;
    [SerializeField] private int damageMeteorite;
    [SerializeField] private ParticleSystem particleMeteorite;
    [SerializeField] private AudioSource audioMeteorite;
    [SerializeField] private GameObject prefab;


    public string DescriptionData => descriptionData;
    public int DamageMeteorite => damageMeteorite;
    public ParticleSystem ParticleMeteorite => particleMeteorite;
    public AudioSource AudioMeteorite => audioMeteorite;
    public GameObject Prefab => prefab;

}
