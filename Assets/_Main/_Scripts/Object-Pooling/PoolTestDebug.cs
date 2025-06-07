using System.Collections;
using UnityEngine;

public class PoolTestDebug : MonoBehaviour
{
    private ObjectPoolGameObject poolBullets;
    private ObjectPoolGameObject poolEnemies;
    [SerializeField]
    private ObjectPoolGameObject pool;
    [SerializeField]
    private int maxTime = 4;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //Simulamos una condicion y tomamos un objeto del pool por ej: el jugador dispara
        {
            Debug.Log("Active un objeto del pool");

            GameObject objCurrent = pool.GetObject(); //se obtiene el objeto del pool y se lo guarda como: OBJETO ACTUAL

            if (objCurrent != null)
            {
                ///Logica del objeto, ej : setearle una nueva posicion
                Debug.Log("El objeto ACTUAL del pool es: " + objCurrent.name);
                objCurrent.transform.position = Vector3.zero; //punto de referencia de donde saldra el objeto.


                ///Ejecutamos la corrutina para generar una condicion que desactive al objeto
                //Condicion que desactive ej: cuando collisione con un objet, cuando este fuera de la pantalla

                // Corrutina que lo devuelve al pool después de X segundos
                StartCoroutine(ReturnToPoolAfterDelay(objCurrent, maxTime));
                
            }

      
        }
    }

    IEnumerator ReturnToPoolAfterDelay(GameObject obj, float delay)
    {
        Debug.Log("Se espera X segundos para devolver el objeto actual");
        yield return new WaitForSeconds(delay);
        //Esto espera una cantidad de X segundos para que se ejecute la siguiente linea


        if (pool != null && obj.activeInHierarchy)
        {
            Debug.Log("Se devolvio y desactivo el objeto actual: " + obj.name);

            //Una vez que la condicion se cumpla
            //Desactivamos el objeto de la jerarquia
            pool.ReturnObject(obj);
        }
    }


}