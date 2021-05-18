using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem.EditorMode;

namespace DialogueSystem.Character
{

    public class CharacterDialogue : MonoBehaviour
    {

        public bool showDialogue;
        public int currentLineIndex;
        public Vector2 scr;

        public string name;
        public string[] dialogueText;

        

        private void OnGUI()
        {
            if (showDialogue)
            {
               
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;

                GUI.Box(new Rect(0, 6 * scr.y, Screen.width, scr.y * 3), name + " : " + dialogueText[currentLineIndex]);

                if (currentLineIndex < dialogueText.Length - 1)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Next"))
                    {
                        currentLineIndex++;
                    }
                }
                else
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Bye"))
                    {
                        showDialogue = false;
                        currentLineIndex = 0;

                        
                        //Cursor.lockState = CursorLockMode.Locked;
                        //Cursor.visible = false;
                    }
                }
            }
        }

    }
}
