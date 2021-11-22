using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem.DialogueNPC
{
    /// <summary>
    /// Who is the NPC?
    /// </summary>
    public abstract class NPC : MonoBehaviour
    {
        [SerializeField] protected private string name; // NPC name

        public abstract void Interact(); //interact function.
    }
}
