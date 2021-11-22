using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem.Character;

namespace DialogueSystem.DialogueNPC
{
    /// <summary>
    /// The NPC that will be interacted with
    /// </summary>
    public class DialogueNPC : NPC
    {
        [SerializeField] private CharacterDialogue dialogue;
        public override void Interact()
        {
            dialogue.showDialogue = true; //if interact then show dialogue
        }
    }
}
