using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem.DialogueNPC;

namespace DialogueSystem.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {


        public CharacterController controller;

        public float speed = 12f;
        public float gravity = -9.81f;

        private Vector3 velocity;

        public float mouseSensitivity = 100f;
        private float xRotation = 0f;

        Camera camera;

        private void Start()
        {
            controller = GetComponent<CharacterController>();//get controller component

            camera = Camera.main;

            Cursor.lockState = CursorLockMode.Locked; //lock mouse
        }

        private void Update()
        {
            MouseLook();
            Move();
            Interact();


        }

        private void MouseLook()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;//getting mouse positions

            xRotation -= mouseY; //getting rotation
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.Rotate(Vector3.up * mouseX); //move camera based on mouse positions

        }

        private void Move()
        {
            float x = Input.GetAxis("Horizontal");

            float z = Input.GetAxis("Vertical");



            Vector3 move = (transform.right * x) + (transform.forward * z);// we want to move inthis direction

            velocity.y += gravity * Time.deltaTime;

            controller.Move((velocity + move) * speed * Time.deltaTime);
        }
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray ray;
                RaycastHit hitInfo;

                ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); //ray from camera


                int layerMask = LayerMask.NameToLayer("Interactable"); //layermask so ray only hits interactable objects.

                layerMask = 1 << layerMask;


                if (Physics.Raycast(ray, out hitInfo, 10f, layerMask)) //if ray hits
                {

                    if (hitInfo.collider.TryGetComponent<NPC>(out NPC npc)) //get the NPC
                    {
                        npc.Interact(); // activate dialogue box
                    }


                }


            }
        }

    }
}
