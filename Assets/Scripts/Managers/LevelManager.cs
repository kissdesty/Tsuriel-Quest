using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Transform puntoReaparicion;
    [SerializeField] private Personaje personaje;



    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            if(personaje.PersonajeVida.Derrotado){
                personaje.transform.localPosition = puntoReaparicion.position;
                personaje.RestaurarPersonaje();
            }
        }


        
    }
}
