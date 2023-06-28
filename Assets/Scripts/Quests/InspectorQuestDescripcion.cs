using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InspectorQuestDescripcion : QuestDescripcion
{
    [SerializeField] private TextMeshProUGUI questRecompensa;
    public override void ConfigurarQuestUI(Quests questPorCargar)
    {
        base.ConfigurarQuestUI(questPorCargar);

        questRecompensa.text = $"-{questPorCargar.RecompensaOro} oro"+
        $"n\n-{questPorCargar.RecompensaExp}exp"+
        $"\n-{questPorCargar.RecompensaItem.Item.Nombre}  x{questPorCargar.RecompensaItem.Cantidad}";
    }

    public void AceptarQuest(){
        if(QuestCargado==null){
            return;
        }
        QuestCargado.QuestAceptado= true;
        QuestManager.Instance.AñadirQuest(QuestCargado);
        gameObject.SetActive(false);
    }
}
