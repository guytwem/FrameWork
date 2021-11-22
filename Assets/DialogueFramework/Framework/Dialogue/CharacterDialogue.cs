using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DialogueSystem.Character
{
    /// <summary>
    /// The setup for the dialogue including GUI box, what is the dialogue and what line of dialogue to be on.
    /// </summary>
    public class CharacterDialogue : MonoBehaviour
    {

        public bool showDialogue;
        public int currentLineIndex;
        public Vector2 scr;

        public string dialogueName;
        public string[] dialogueText;

       

        private void OnGUI()
        {
            if (showDialogue) //if showing dialogue
            {
                Cursor.lockState = CursorLockMode.None; //unlock the mouse
                Cursor.visible = true;
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;

                GUI.Box(new Rect(0, 6 * scr.y, Screen.width, scr.y * 3), name + " : " + dialogueText[currentLineIndex]); //setting dialogue box

                if (currentLineIndex < dialogueText.Length - 1) //if there is more dialogue display next button
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Next"))
                    {
                        currentLineIndex++;
                    }
                }
                else //if dialogue is done then bye button will close out dialogue
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Bye"))
                    {
                        showDialogue = false;
                        currentLineIndex = 0;

                        Cursor.lockState = CursorLockMode.Locked; //relock the mouse
                        Cursor.visible = false;

                    }
                }
            }
        }

    }
}
