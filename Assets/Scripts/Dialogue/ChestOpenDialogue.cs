using System.Collections;
using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class ChestOpenDialogue : Dialogue
{
    [SerializeField] private DialogManager DialogManager;
    
    public override void Talk()
    {
        if (DialogManager.Printer.activeSelf) {
            return;
        }
        
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/speed:down/Sigh.../wait:1//close/", "Captain", isSkipable: false));
        dialogTexts.Add(new DialogData("Why.../wait:1/Why is it empty?/wait:1//close/", "Captain", isSkipable: false));
        dialogTexts.Add(new DialogData("To think my crew had the gall to ask me for /speed:up/dental. Dental!/wait:1//close/", "Captain", isSkipable: false));
        dialogTexts.Add(new DialogData("/speed:down/On international waters!/wait:1//close/", "Captain", isSkipable: false));
        
        DialogManager.Show(dialogTexts);
    }
}
