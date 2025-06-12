using System.Collections.Generic;
using UnityEngine;

///Creamos un pool que pueda permitir crear varios pools para cada elemento dada una lista
public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private Transform _container;

    [SerializeField]
    private int _size;

    private Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();

    public static PoolManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void CreatePool(GameObject prefabKey)
    {
        if (pools.ContainsKey(prefabKey)) return; // Si ya existe un pool para ese prefab, no hacer nada

        List<GameObject> poolListValue = new List<GameObject>();

        for (int i = 0; i < _size; i++)
        {
            GameObject obj = Instantiate(prefabKey, _container);
            obj.name = $"{prefabKey.name}_{i}";
            obj.SetActive(false);
            poolListValue.Add(obj);
        }

        pools.Add(prefabKey, poolListValue);
    }

    /// <summary>
    /// Obtiene un objeto activo del pool para el prefab indicado.
    /// </summary>
    public GameObject GetObject(GameObject keyPrefab)
    {
        if (!pools.ContainsKey(keyPrefab))
        {
            Debug.LogWarning("No existe un pool para este prefab: " + keyPrefab.name);
            return null;
        }

        List<GameObject> poolList = pools[keyPrefab];

        foreach (GameObject obj in poolList)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        Debug.LogWarning("No hay objetos disponibles en el pool para el prefab: " + keyPrefab.name);
        return null;
    }

    /// <summary>
    /// Devuelve un objeto al pool (lo desactiva).
    /// </summary>
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }

}
