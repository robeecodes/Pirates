using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class TavernDialogue : Dialogue
{
    [SerializeField] private DialogManager DialogManager;
    [SerializeField] private LevelLoader levelLoader;

    public override void Talk()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Have, you seen, a, uh... A little... guy?/wait:3//close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Are you, perhaps, referring to the one other stranger here with a massive head?/wait:1//close/", "Bartender", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Argh, ye, that be the one!/wait:1//close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Well, he's... Yeah... Just over there./wait:3//close/", "Bartender", isSkipable: false));
        
        dialogTexts.Add(new DialogData("H-hey Captain, this apple juice goes crazy!/wait:1//close/", "First Mate", isSkipable: false));
        
        dialogTexts.Add(new DialogData("/speed:down/.../wait:2//close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Uh.../speed:init/ What's wrong with him?/wait:1//close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("It's hard to really say, a sugar rush, I think?/wait:1//close/", "Bartender", isSkipable: false));
        
        dialogTexts.Add(new DialogData("C-captain... /speed:down/Captain.../speed:up//wait:1/ Look at this craaaaaaazy fruit!/wait:5//close/", "First Mate", isSkipable: false));
        
        dialogTexts.Add(new DialogData("/speed:down/.../speed:up//wait:1//close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("To be fair, that is a pretty crazy fruit./wait:3//close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Is he... Is he okay to stay here?/wait:1//close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Long as he doesn't get rowdy, I really don't care./wait:1//close/", "Bartender", () => levelLoader.LoadLevel("PirateTavern"), isSkipable: false));

        DialogManager.Show(dialogTexts);
    }
}
