using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;
using Random = UnityEngine.Random;

public class WandererDialogue : Dialogue {
    [SerializeField] private DialogManager DialogManager;

    private List<string> _optionsHappy;
    private List<string> _optionsNeutral;
    private List<string> _optionsScared;

    private Navigation _me;
    private void Awake() {
        _optionsHappy = new List<string> {
            "Thanks for all your help!/wait:1//close/",
            "It's nice to see you!/wait:1//close/",
            "Your ship is so cool!/wait:1//close/",
            "Will you be staying a while?/wait:1//close/"
        };

        _optionsNeutral = new List<string> {
            "Oh, awesome, a pirate./wait:1/ You'd better not be causing any trouble!/wait:1//close/",
            "Do you have a reason to be here, or?/wait:1//close/",
            "Your kind probably belongs in the tavern./wait:1//close/"
        };

        _optionsScared = new List<string> {
            "P-please... LEAVE ME ALONE!/wait:1//close/",
            "GET AWAY FROM ME!/wait:1//close/"
        };
    }

    public void InitMe(Navigation wanderer) {
        _me = wanderer;
    }
    
    public override void Talk() {
        if (DialogManager.Printer.activeSelf) {
            return;
        }

        var text = "...";

        if (_me.state == Navigation.State.Happy) {
            text = _optionsHappy[Random.Range(0, _optionsHappy.Count)];
        } else if (_me.state == Navigation.State.Neutral) {
            text = _optionsNeutral[Random.Range(0, _optionsNeutral.Count)];
        }
        else {
            text = _optionsScared[Random.Range(0, _optionsScared.Count)];
        }
        
        
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData(text, "Wanderer", isSkipable: false));

        DialogManager.Show(dialogTexts);
    }
}