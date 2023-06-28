using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemigoVida : VidaBase
{
    public static Action <float> EventoEnemigoDerrotado;
    [Header("Vida")]
    [SerializeField] private EnemigoBarraVida barraVidaPrefab;
    [SerializeField] private Transform barraVidaPosicion;
    [Header("Rastros")]
    [SerializeField] private GameObject rastros;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    private EnemigoBarraVida _enemigoBarraVidaCreada;
    private EnemigoInteraccion _enemigoInteraccion;
    private EnemigoMovimiento _enemigoMovimiento;
    private IAController _controller;
    private EnemigoLoot _enemigoLoot;

    private void Awake() {
        _spriteRenderer= GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _controller = GetComponent<IAController>();
        _enemigoInteraccion = GetComponent<EnemigoInteraccion>();
        _enemigoMovimiento = GetComponent<EnemigoMovimiento>();
        _enemigoLoot = GetComponent<EnemigoLoot>();
    }

    protected override  void Start(){
        base.Start();
        CrearBarraVida();
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax){
        _enemigoBarraVidaCreada.ModificarSalud(vidaActual, vidaMax);

    }

    private void CrearBarraVida(){
        _enemigoBarraVidaCreada= Instantiate(barraVidaPrefab,barraVidaPosicion);
        ActualizarBarraVida(Salud,saludMax);
    }

    private void DesactivarEnemigo(){
        _enemigoBarraVidaCreada.gameObject.SetActive(false);
        _spriteRenderer.enabled= false;
        _controller.enabled= false;
        _boxCollider2D.isTrigger= true;
        _enemigoInteraccion.DesactivarSpritesSeleccion();
        _enemigoMovimiento.enabled=false;
        rastros.SetActive(true);
    }

    protected override void PersonajeDerrotado(){
        DesactivarEnemigo();
        EventoEnemigoDerrotado?.Invoke(_enemigoLoot.ExpGanada);
        QuestManager.Instance.AñadirProgreso("Mata10",1);
        QuestManager.Instance.AñadirProgreso("Mata15",1);
        QuestManager.Instance.AñadirProgreso("Mata25",1);
    } 

}
