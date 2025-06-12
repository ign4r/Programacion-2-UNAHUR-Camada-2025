using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Actors", menuName = "Actors/Collection", order = 0)]
public class ActorCollectionData : ScriptableObject
{
    [SerializeField] private List<GameObject> prefabs;
    public List<GameObject> Prefabs => prefabs;

}



