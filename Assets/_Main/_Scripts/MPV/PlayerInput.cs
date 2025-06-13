using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private FSMController _fsmController;


    void Update()
    {
       // El hecho de que llames a un metodo publico para cambiar de estado, ya es un “evento” en la logica.

        if (Input.GetKey(KeyCode.D))
            _fsmController.OnDanceEvent();

        else if (Input.GetKeyDown(KeyCode.A))
            _fsmController.OnAttackEvent();

        else if (Input.GetKey(KeyCode.M))
            _fsmController.OnMoveEvent();

        else
            _fsmController.OnIdleEvent();
    }


}



