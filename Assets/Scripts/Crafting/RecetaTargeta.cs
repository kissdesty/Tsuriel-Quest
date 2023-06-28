using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RecetaTargeta : MonoBehaviour
{
    [SerializeField] private Image recetaIcono;
    [SerializeField] private TextMeshProUGUI recetaNombre;
    public Receta RecetaCargada { get; private set; }
    
    public void ConfigurarRecetaTargeta(Receta receta){
        RecetaCargada= receta;
        recetaIcono.sprite= receta.ItemResultado.Icono;
        recetaNombre.text= receta.ItemResultado.Nombre;

    }
    public void SeleccionarReceta(){
        CraftingManager.Instance.MostrarReceta(RecetaCargada);
        UIManager.Instance.AbrirCerrarPanelCraftingInformacion(true);
    }

}
