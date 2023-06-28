using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Items/Pocion Mana")]
public class ItemPocionMana : InventarioItem
{
    [Header("Pocion info")]
    public float MPRestauracion;

   public  override bool UsarItem(){
    if(Inventario.Instance.Personaje.PersonajeMana.SePuedeRestaurar){
        Inventario.Instance.Personaje.PersonajeMana.RestaurarMana(MPRestauracion);
        return true;
    }
    return false;
   }

       public override string DescripcionItemCrafting()
    {
        string descripcion = $"Restaura{MPRestauracion} de Mana";
        return descripcion;
    }

     
}
