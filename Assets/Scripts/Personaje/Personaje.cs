using UnityEngine;
using System;
public class Personaje : MonoBehaviour
{
   [SerializeField] private PersonajeStats stats;
   public PersonajeAtaque PersonajeAtaque { get; private  set; }
   public PersonajeExperiencia PersonajeExperiencia {get; private set;}
    public PersonajeVida PersonajeVida { get; private set; }
    public PersonajeAnimaciones PersonajeAnimaciones { get;  private set; }
    public PersonajeMana PersonajeMana {get; private set;}


 private void Awake(){
   PersonajeAtaque = GetComponent<PersonajeAtaque>();
    PersonajeVida= GetComponent<PersonajeVida>();
    PersonajeAnimaciones= GetComponent<PersonajeAnimaciones>();
    PersonajeMana = GetComponent<PersonajeMana>();
    PersonajeExperiencia= GetComponent<PersonajeExperiencia>();
 }

 public void RestaurarPersonaje(){
    PersonajeVida.RestaurarPersonaje();
    PersonajeAnimaciones.RevivirPersonaje();
    PersonajeMana.RestablecerMana();
 }


 private void AtributoRespuesta(TipoAtributo tipo){
   Debug.Log("Hola2");

   if(stats.PuntosDisponibles<=0){
      Debug.Log("Hola");
      return;
   }

   switch(tipo){
      case TipoAtributo.Fuerza:
         stats.Fuerza++;
         stats.AñadirBonusPorAtributoFuerza();
         break;
      case TipoAtributo.Inteligencia:
         stats.Inteligencia++;
         stats.AñadirBonusPorAtributoInteligencia();
         break;
      case TipoAtributo.Destreza:
         stats.Destreza++;
         stats.AñadirBonusPorAtributoDestreza();
         break;
   }
   stats.PuntosDisponibles -= 1;

 }


    private void OnEnable()
    {
        AtributoButton.EventoAgregarAtributo += AtributoRespuesta;
    }

    private void OnDisable()
    {
        AtributoButton.EventoAgregarAtributo -= AtributoRespuesta;
    }
}
