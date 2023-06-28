using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestDescripcion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questNombre;
    [SerializeField] private TextMeshProUGUI questDescripcion;

    public Quests QuestCargado {get; set;}

    public virtual void ConfigurarQuestUI(Quests quest){
        QuestCargado= quest;
        questNombre.text= quest.Nombre;
        questDescripcion.text= quest.Descripcion;
    }
}
