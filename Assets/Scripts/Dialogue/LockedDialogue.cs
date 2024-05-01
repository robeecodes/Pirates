using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;
using Random = UnityEngine.Random;

public class LockedDialogue : Dialogue {
    [SerializeField] private DialogManager DialogManager;

    private List<string> _options;

    private void Awake() {
        _options = new List<string>();
        _options.Add("It's locked./wait:1//close/");
        _options.Add("It's locked.../wait:1/ ...Locked and I really don't feel like breaking in./wait:1//close/");
        _options.Add("So, uh.../wait:1/ Looks like the Tavern's where it's at today!/wait:1//close/");
        _options.Add("I mean.../wait:1/ Looks like the whole town is either wandering or in the Tavern!/wait:1//close/");
    }

    public override void Talk() {
        if (DialogManager.Printer.activeSelf) {
            return;
        }
        var text = _options[Random.Range(0, _options.Count)];
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData(text, "Captain", isSkipable: false));

        DialogManager.Show(dialogTexts);
    }
}