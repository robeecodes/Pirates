using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.SceneManagement;

public class IntroDialogue : MonoBehaviour
{
    [SerializeField] private DialogManager DialogManager;
    [SerializeField] private LevelLoader levelLoader;
    
    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Well, what do you think Captain? Are we nearly there?/wait:3//close/", "First Mate", isSkipable: false));
        
        dialogTexts.Add(new DialogData("That's a/speed:down/... uh... /speed:up/difficult question./speed:init/ We're not going anywhere in particular./wait:1//close/", "Captain", isSkipable: false));

        dialogTexts.Add(new DialogData("Oh, come on Captain! If I know you, I know you've got a plan!/wait:1.0//close/", "First Mate", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Yep. I just can't wait to find an island to pillage! Fire all their cannons, destroy all their crops!/wait:1//close/", "First Mate", isSkipable: false));
        
        dialogTexts.Add(new DialogData("/speed:down/.../wait:1.0//close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Or... We could always not do that, I suppose./wait:1/ You could try being friendly... Water their crops or something..../wait:1//close/", "First Mate", isSkipable: false));
        
        dialogTexts.Add(new DialogData("/speed:up/You concern me sometimes./speed:init/ Look, once we find somewhere to--/wait:0.5//close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Wow, look! An island!/wait:1//close/", "First Mate", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Indeed there is! Well, let's get ready to dock./close/", "Captain", isSkipable: false));
        
        dialogTexts.Add(new DialogData("Aye aye, Captain!/wait:1//close/", "First Mate",(() => levelLoader.LoadLevel("Main")), isSkipable: false));
        
        DialogManager.Show(dialogTexts);
    }
}
