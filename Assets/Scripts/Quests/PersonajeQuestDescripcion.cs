using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PersonajeQuestDescripcion : QuestDescripcion
{

    [SerializeField] private TextMeshProUGUI tareaObjetivo;
    [SerializeField] private TextMeshProUGUI recompensaExp;

    [SerializeField] private TextMeshProUGUI recompensaOro;

    [Header("Item")]
    [SerializeField] private Image recompensaItemIcono;
    [SerializeField] private TextMeshProUGUI recompensaItemCantidad;

    private void Update(){
        if(QuestCargado.QuestCompletadoCheck){
            return;
        }
        tareaObjetivo.text= $"{QuestCargado.CantidadActual}/{QuestCargado.CantidadObjetivo}";

    }


    public override void ConfigurarQuestUI(Quests questPorCargar){
        base.ConfigurarQuestUI(questPorCargar);
        recompensaOro.text= questPorCargar.RecompensaOro.ToString();
        recompensaExp.text= questPorCargar.RecompensaExp.ToString();
        tareaObjetivo.text= $"{questPorCargar.CantidadActual}/{questPorCargar.CantidadObjetivo}";

        recompensaItemIcono.sprite =questPorCargar.RecompensaItem.Item.Icono;
        recompensaItemCantidad.text= questPorCargar.RecompensaItem.Cantidad.ToString();

    } 

    private void QuestCompletadoRespuesta(Quests questCompletado){
        if(questCompletado.ID == QuestCargado.ID){
             tareaObjetivo.text= $"{QuestCargado.CantidadActual}/{QuestCargado.CantidadObjetivo}";
             gameObject.SetActive(false);

        }
    }
    private void OnEnable(){
        if(QuestCargado.QuestCompletadoCheck){
            gameObject.SetActive(false);
        }
        Quests.EventoQuestCompletado += QuestCompletadoRespuesta;
    }

    private void OnDisable(){
        Quests.EventoQuestCompletado-= QuestCompletadoRespuesta;
    }
}
