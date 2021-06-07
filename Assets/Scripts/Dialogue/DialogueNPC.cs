using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem.Character;

namespace DialogueSystem.DialogueNPC
{
    public class DialogueNPC : NPC
    {
        [SerializeField] private CharacterDialogue dialogue;
        public override void Interact()
        {
            dialogue.showDialogue = true;
        }
    }
}
