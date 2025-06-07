using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolGameObject : MonoBehaviour
{
    [Header("Configuración del Pool")]

    public GameObject prefab; //Objeto a instanciar
    public GameObject containerObjects; //parent de los objetos
    public int poolSize = 10; //es decir la cantidad de objetos 

    public List<GameObject> pool; ///tendria todos los objetos creados
    // en el mismo pool un enemigo una bala NO

    void Awake()
    {
        //1 paso
        //LA CREACION DE LOS OBJETOS Y AÑADIRLOS A UNA LISTA, QUE VENDRIA A SER EL POOL
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, containerObjects.transform); //instanciamos
            obj.name = prefab.name + "_" + i;
            obj.SetActive(false); //desactivamos en cada iteracion
            pool.Add(obj); //y añadimos cada uno de los objetos en la lista
        }
    }

    //2 paso: crear estos dos metodos
    // Crear un metodo para obtener un objeto del pool, y otro para devolver un objeto al pool


    /// <summary>
    /// Devuelve un objeto del pool. Si no hay disponibles, crea uno nuevo.
    /// </summary>
    public GameObject GetObject() //Tomamos un objeto del pool, lo que hacemos es activarlo
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
    public void ReturnObject(GameObject obj) ///
    {
        obj.SetActive(false);
    }
}

