using UnityEngine;
using UnityEditor;
using DialogueSystem.Character;

namespace DialogueSystem.EditorMode
{

    public class Dialogue : EditorWindow
    {
        //Does not work as intended




        /*
        private CharacterDialogue cd;
        private string editName = "Enter Name";
        [MenuItem("Window/Dialogue")]
        public static void ShowWindow()
        {
            GetWindow<Dialogue>("Dialogue");
        }

        private void OnGUI()
        {

            if (Selection.activeTransform.gameObject == null)
            {
                GUILayout.Label("Select a GameObject to Add or Change Dialogue");
            }


            if (Selection.activeTransform.gameObject != null &&
                Selection.activeTransform.gameObject.GetComponent<CharacterDialogue>() == null)

            {

                GUILayout.Label("Create a Dialogue");
                if (GUILayout.Button("Create"))
                {
                    ApplyScript();
                }
            }
            if (Selection.activeTransform.gameObject != null &&
                Selection.activeTransform.gameObject.GetComponent<CharacterDialogue>() != null)
            {
                
                GUILayout.Label("edit dialogue things");
                editName = GUILayout.TextField(editName);
                Selection.activeTransform.gameObject.GetComponent<CharacterDialogue>().dialogueName = editName;


            }



        }

        void ApplyScript()
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                if (obj.GetComponent<CharacterDialogue>() == null)
                {
                    obj.AddComponent<CharacterDialogue>();
                    Debug.Log("Character Dialogue Added");
                }
                else
                {
                    Debug.Log("Dialogue Already Created on that Object");
                }

            }
        }
        */

    }

}


