using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirstMateTavernDialogue : Dialogue {
    [SerializeField] private DialogManager DialogManager;

    private List<string> _options;

    private void Awake() {
        _options = new List<string> {
            "Don't worry about me, Captain, you go and have fun!/wait:1//close/",
            "Please don't forget to bring me home with you./wait:1//close/",
            "They have quite a lot of dragon fruit here, yum!/wait:1//close/",
            "C-captain! Can I have a pizza?/wait:1//close/"
        };
    }

    public override void Talk() {
        if (DialogManager.Printer.activeSelf) {
            return;
        }
        var text = _options[Random.Range(0, _options.Count)];
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData(text, "First Mate", isSkipable: false));

        DialogManager.Show(dialogTexts);
    }
}