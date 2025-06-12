using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Actors", menuName = "Actors/Prefabs/List", order = 1)]
public class DataPrefabs : ScriptableObject
{
    [SerializeField] private List<GameObject> prefabs;
    public List<GameObject> Prefabs => prefabs;

}
