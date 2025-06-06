using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolGameObject : MonoBehaviour
{
    [Header("Configuración del Pool")]
    public GameObject prefab;
    public GameObject containerObjects;
    public int poolSize = 10;

    public List<GameObject> pool;

    void Awake()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, containerObjects.transform);
            obj.name = prefab.name + "_" + i;
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    /// <summary>
    /// Devuelve un objeto del pool. Si no hay disponibles, crea uno nuevo.
    /// </summary>
    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        Debug.LogError("No hay objetos disponibles en el pool.");
        return null;
        /// Opcional: instanciar otro objeto si el pool lo necesita
        //GameObject newObj = Instantiate(prefab);
        //newObj.SetActive(true);
        //pool.Add(newObj);
        //return newObj;
    }

    /// <summary>
    /// Devuelve un objeto al pool (lo desactiva).
    /// </summary>
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}

