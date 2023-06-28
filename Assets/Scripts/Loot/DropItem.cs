using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DropItem 
{

[Header("info")]
    public string Nombre;
    public InventarioItem Item;
    public int Cantidad;
    
    [Header("Drop")]
    [Range(0,100)] public float PorcentajeDrop;

    public bool ItemRecogido { get; set; }

}
