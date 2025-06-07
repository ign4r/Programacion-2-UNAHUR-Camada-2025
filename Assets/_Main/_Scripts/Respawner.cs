using System.Collections;
using UnityEngine;


public class Respawner : MonoBehaviour
{
    [SerializeField] private BoxCollider respawnArea;     // Asignar en inspector
    [SerializeField] private float respawnY = 1f;          // Altura de respawn
    [SerializeField] private MeteoriteDataObject[] dataMeteorites; // Array de prefabs
    [SerializeField] private float spawnInterval = 2f;     // Intervalo entre spawns

    private void Start()
    {
        if (dataMeteorites == null || dataMeteorites.Length == 0)
        {
            Debug.LogError("No hay objetos asignados para instanciar.");
            return;
        }

        StartCoroutine(SpawnObjectsRoutine());
    }

    private IEnumerator SpawnObjectsRoutine()
    {
        while (true)
        {
            MeteoriteDataObject data = dataMeteorites[Random.Range(0, dataMeteorites.Length)]; //Elegi un random de la lista

            GameObject objPrefab = Instantiate(data.Prefab);
            RespawnAtRandomX(objPrefab);//Respawnea un objeto en una posicion random en X
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    ///Detecta si tocaron el piso y vuelven a aparecer.
    private void OnTriggerEnter(Collider other)
    {
        if (respawnArea == null) return;

        if (other.CompareTag("Coin") || other.CompareTag("Meteorite"))
        {
            RespawnAtRandomX(other.gameObject);
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
