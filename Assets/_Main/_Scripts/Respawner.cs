using System.Collections;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private BoxCollider respawnArea;     // Asignar en inspector
    [SerializeField] private float respawnY = 1f;          // Altura de respawn
    [SerializeField] private ActorCollectionData meteoritesCollect;
    [SerializeField] private float spawnInterval = 2f;     // Intervalo entre spawns
   //[SerializeField] private ActorCollectionData<MeteoritePresenter> meteoritesCollectG;



    private void Start()
    {
        InitializationPool(meteoritesCollect);
        StartCoroutine(SpawnObjectsRoutine(meteoritesCollect));
    }
    public void InitializationPool(ActorCollectionData collectionData)
    {
        if (collectionData == null || collectionData.Prefabs.Count == 0)
        {
            Debug.LogError("No hay objetos asignados para instanciar.");
            return;
        }

        foreach (var prefab in collectionData.Prefabs)
        {
            PoolManager.Instance.CreatePool(prefab);
        }
    }


    private IEnumerator SpawnObjectsRoutine(ActorCollectionData collectionData)
    {
        while (true)
        {
            GameObject prefabRandom = collectionData.Prefabs[Random.Range(0, collectionData.Prefabs.Count)];
            GameObject objSelected = PoolManager.Instance.GetObject(prefabRandom);
            if (objSelected != null)
            {
                RespawnAtRandomX(objSelected);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    ///Detecta si tocaron el piso y vuelven a aparecer.
    private void OnTriggerEnter(Collider other)
    {
        if (respawnArea == null) return;

        if (other.CompareTag("Meteorite"))
        {
            PoolManager.Instance.ReturnObject(other.gameObject);
        }
    }

    public void RespawnAtRandomX(GameObject obj) 
    {
        Vector3 center = respawnArea.bounds.center;
        float halfWidth = respawnArea.bounds.extents.x;

        float randomX = Random.Range(center.x - halfWidth, center.x + halfWidth);
        Vector3 respawnPos = new Vector3(randomX, respawnY, 0);

        obj.transform.position = respawnPos;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
