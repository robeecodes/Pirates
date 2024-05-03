using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;
using Random = UnityEngine.Random;

public class HitInvisibleWallDialogue : Dialogue {
    [SerializeField] private DialogManager DialogManager;

    private List<string> _options;

    private void Awake() {
        _options = new List<string>();
        _options.Add("So, I'm just wondering... How far do you think I can swim?/wait:1//close/");
        _options.Add("Have you noticed how we aren't going anywhere? Almost like you should stop swimming./wait:1//close/");
        _options.Add("This sea water's nice and all... But can we go back to land?/wait:1//close/");
        _options.Add("You can't seriously be trying to abandon my poor first mate? He's just a boy!/wait:1//close/");
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