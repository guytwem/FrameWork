using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem.DialogueNPC
{
    public abstract class NPC : MonoBehaviour
    {
        [SerializeField] protected private string name; // NPC name

        public abstract void Interact();
    }
}
