using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>



{
    [Header ("Stats")]
    [SerializeField] private PersonajeStats stats;
    [Header ("Paneles")]
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelTienda;
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private GameObject panelInspectorQuest;
    [SerializeField] private GameObject panelPersonajeQuest;
    [SerializeField] private GameObject panelCrafting;
    [SerializeField] private GameObject panelCraftingInfo;


    [Header("Barra")]
    [SerializeField] private Image  vidaPlayer;

    [SerializeField] private Image  manaPlayer;
    [SerializeField] private Image  expPlayer;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI nivelTMP;
    [SerializeField] private TextMeshProUGUI monedasTMP;

    [Header("Stats")]

    [SerializeField] private TextMeshProUGUI statDañoTMP;
    [SerializeField] private TextMeshProUGUI statDefensaTMP;
    [SerializeField] private TextMeshProUGUI statCriticoTMP;
    [SerializeField] private TextMeshProUGUI statBloqueoTMP;
    [SerializeField] private TextMeshProUGUI statVelocidadTMP;
    [SerializeField] private TextMeshProUGUI statNivelTMP;
    [SerializeField] private TextMeshProUGUI statExpTMP;
    [SerializeField] private TextMeshProUGUI statExpRequeridaTMP;
    [SerializeField] private TextMeshProUGUI statExpTotalTMP;

    [SerializeField] private TextMeshProUGUI atributosFuerzaTMP;
    [SerializeField] private TextMeshProUGUI atributosInteligenciaTMP;
    [SerializeField] private TextMeshProUGUI atributosDestrezaTMP;
    [SerializeField] private TextMeshProUGUI atributosDisponiblesTMP;





    private float vidaActual;
    private float vidaMax;
    private float manaActual;
    private float manaMax;
    private float expActual;
    private float expRequeridaNuevoNivel;

    void Update()
    {
        ActualizarUIPersonaje();
        ActualizarPanelStats();
        
    }

    private void ActualizarUIPersonaje(){
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, vidaActual/vidaMax, 10f *Time.deltaTime);
        vidaTMP.text = $"{vidaActual}/{vidaMax}";

        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount, manaActual/manaMax, 10f *Time.deltaTime);
        manaTMP.text = $"{manaActual}/{manaMax}";
        

        
        expPlayer.fillAmount = Mathf.Lerp(expPlayer.fillAmount, expActual/expRequeridaNuevoNivel, 10f *Time.deltaTime);
        expTMP.text = $"{((expActual/expRequeridaNuevoNivel)*100):F2}%";

        nivelTMP.text=  $"Nivel {stats.Nivel}";
        monedasTMP.text= MonedasManager.Instance.MonedasTotales.ToString();
    }

    private void ActualizarPanelStats(){
        if(panelStats.activeSelf==false){
            return;
        }

    statDañoTMP.text= stats.Daño.ToString();
    statDefensaTMP.text= stats.Defensa.ToString();
    statCriticoTMP.text= $"{stats.PorcentajeCritico}%";
    statBloqueoTMP.text= $"{stats.PorcentajeBloqueo}%";
    statVelocidadTMP.text= stats.Velocidad.ToString();
    statNivelTMP.text= stats.Nivel.ToString();
    statExpTMP.text= stats.ExpActual.ToString();
    statExpRequeridaTMP.text= stats.ExpActual.ToString();
    statExpTotalTMP.text = stats.ExpTotal.ToString();

    atributosFuerzaTMP.text= stats.Fuerza.ToString();
    atributosInteligenciaTMP.text = stats.Inteligencia.ToString();
    atributosDestrezaTMP.text = stats.Destreza.ToString();
    atributosDisponiblesTMP.text=  $"Puntos :{stats.PuntosDisponibles}";

    }

    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax){
        vidaActual= pVidaActual;
        vidaMax= pVidaMax;
    }

        public void ActualizarManaPersonaje(float pManaActual, float pManaMax){
        manaActual= pManaActual;
        manaMax= pManaMax;
    }

           public void ActualizarExpPersonaje(float pExpActual, float pExpRequerida){
        expActual= pExpActual;
        expRequeridaNuevoNivel= pExpRequerida;
    }
    #region Paneles

    public void AbrirCerrarPanelStats(){
        panelStats.SetActive(!panelStats.activeSelf);
    }
    public void AbrirCerrarPanelCraftingInformacion(bool estado){
        panelCraftingInfo.SetActive(estado);
    }

    public void AbrirCerrarPanelInventario(){
        panelInventario.SetActive(!panelInventario.activeSelf);
    }

    public void AbrirCerrarPanelInspectorQuests(){
        panelInspectorQuest.SetActive(!panelInspectorQuest.activeSelf);
    }
    public void AbrirCerrarPanelPersonajeQuests(){
        panelPersonajeQuest.SetActive(!panelPersonajeQuest.activeSelf);
    }
    public void AbrirPanelCrafting(){
        panelCrafting.SetActive(true);
    }

    public void CerrarPanelCrafting(){
        panelCrafting.SetActive(false);
        AbrirCerrarPanelCraftingInformacion(false);
    }
    public void AbrirCerrarPanelTienda(){
        panelTienda.SetActive(!panelTienda.activeSelf);
    }

    public void AbrirPanelInteraccion(InteraccionExtraNPC tipoInteraccion){

        switch(tipoInteraccion){
            case InteraccionExtraNPC.Quests:
            AbrirCerrarPanelInspectorQuests();
            break;
             case InteraccionExtraNPC.Tienda:
             AbrirCerrarPanelTienda();
            break;
             case InteraccionExtraNPC.Crafting:
             AbrirPanelCrafting();
            break;
        }

    }

    #endregion
}
