using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QuestManager : Singleton<QuestManager>
{


    [Header("Personaje")]

    [SerializeField] private Personaje personaje;
    [Header("Quests")]
    [SerializeField] private Quests[] questDisponibles;


    [Header("Inspector Quests")]
    [SerializeField] private InspectorQuestDescripcion inspectorQuestPrefab;
    [SerializeField] private Transform inspectorQuestContenedor;

    [Header("Personaje Quests")]
    [SerializeField] private PersonajeQuestDescripcion personajeQuestPrefab;
    [SerializeField] private Transform personajeQuestContenedor;

     [Header("Panel Quests Completado")]
    [SerializeField] private GameObject panelQuestCompletado;
    [SerializeField] private TextMeshProUGUI questNombre;
    [SerializeField] private TextMeshProUGUI questRecompensaOro;
    [SerializeField] private TextMeshProUGUI questRecompensaExp;
    [SerializeField] private TextMeshProUGUI questRecompensaItemCantidad;
    [SerializeField] private Image  questRecompensaItemIcono;
    public Quests QuestPorReclamar{ get; private set;}

    void Start()
    {
        CargarQuestEnInspector();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.V)){
            AñadirProgreso("Mata10",1);
            AñadirProgreso("Mata15",1);
            AñadirProgreso("Mata25",1);
        }
    }


    private void CargarQuestEnInspector(){
        for(int i=0; i<questDisponibles.Length; i++){

         InspectorQuestDescripcion nuevoQuest = Instantiate(inspectorQuestPrefab, inspectorQuestContenedor);
         nuevoQuest.ConfigurarQuestUI(questDisponibles[i]);

        }
    }

    private void AñadirQuestPorCompletar(Quests questPorCompletar){
        PersonajeQuestDescripcion nuevoQuest = Instantiate( personajeQuestPrefab, personajeQuestContenedor);
        nuevoQuest.ConfigurarQuestUI(questPorCompletar);
    }

    public void AñadirQuest(Quests questPorCompletar){
        AñadirQuestPorCompletar(questPorCompletar);
    }
    public void AñadirProgreso(string questID,int cantidad){
        Quests questPorActualizar = QuestExiste(questID);

        if(questPorActualizar.QuestAceptado){
          questPorActualizar.AñadirProgreso(cantidad);
        }
    }

    private Quests QuestExiste(string questID){
        for(int i=0; i<questDisponibles.Length; i++){
            if(questDisponibles[i].ID== questID){
                return questDisponibles[i];

            }
        }
        return null;
    }

    private void MostrarQuestCompletado(Quests questCompletado){
        panelQuestCompletado.SetActive(true);
        questNombre.text = questCompletado.Nombre;
        questRecompensaOro.text= questCompletado.RecompensaOro.ToString();
        questRecompensaExp.text = questCompletado.RecompensaExp.ToString();
        questRecompensaItemCantidad.text= questCompletado.RecompensaItem.Cantidad.ToString();
        questRecompensaItemIcono.sprite= questCompletado.RecompensaItem.Item.Icono;
    }

    private void QuestCompletadoRespuesta(Quests questCompletado){
        QuestPorReclamar= QuestExiste(questCompletado.ID);
        if(QuestPorReclamar!=null){
            MostrarQuestCompletado(QuestPorReclamar);
        }
    }
    public void ReclamarRecompensa(){
        if(QuestPorReclamar==null){
            return;
        }

        MonedasManager.Instance.AñadirMonedas(QuestPorReclamar.RecompensaOro);
        personaje.PersonajeExperiencia.AñadirExperiencia(QuestPorReclamar.RecompensaExp);

        Inventario.Instance.AñadirItem(QuestPorReclamar.RecompensaItem.Item, QuestPorReclamar.RecompensaItem.Cantidad);
        panelQuestCompletado.SetActive(false);
        QuestPorReclamar= null;
    }

    private void OnEnable(){
        Quests.EventoQuestCompletado += QuestCompletadoRespuesta;
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            questDisponibles[i].ResetQuest();
        }
    }



    private void OnDisable(){
         Quests.EventoQuestCompletado -= QuestCompletadoRespuesta;

    }

}
