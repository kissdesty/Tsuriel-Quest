using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoArma{
    Magia, Melee
}

[CreateAssetMenu(menuName="Personaje/Arma")]
public class Arma : ScriptableObject
{
[Header("Config")]
public Sprite ArmaIcono;
public Sprite IconoSkill;

public TipoArma Tipo;
public float Daño;

[Header("Arma Magica")]
public float ManaRequerida;
public Proyectil ProyectilPrefab;

[Header("Stats")]
public float ChanceCritico;
public float ChanceBloqueo;
}
