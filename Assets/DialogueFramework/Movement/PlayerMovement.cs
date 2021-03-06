using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem.DialogueNPC;

namespace DialogueSystem.Movement
{
    /// <summary>
    /// The player movement controls that allows you to move around and interact with npc's.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {


        public CharacterController controller; //ref to character controller

        public float speed = 12f; //player speed
        public float gravity = -9.81f; //player gravity

        private Vector3 velocity;

        public float mouseSensitivity = 100f;
        private float xRotation = 0f;

        Camera camera;

        private void Start()
        {
            controller = GetComponent<CharacterController>();//get controller component

            camera = Camera.main; //setting main cam

            Cursor.lockState = CursorLockMode.Locked; //lock mouse
        }

        private void Update()
        {
            MouseLook();
            Move();
            Interact();


        }
        
        /// <summary>
        /// gets mouse positions and uses it to move the camera.
        /// </summary>
        private void MouseLook()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;//getting mouse positions

            xRotation -= mouseY; //getting rotation
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.Rotate(Vector3.up * mouseX); //move camera based on mouse positions

        }
        
        /// <summary>
        /// gets horizontal and vertical axis, uses it to move the player gameObject.
        /// </summary>
        private void Move()
        {
            float x = Input.GetAxis("Horizontal");

            float z = Input.GetAxis("Vertical");



            Vector3 move = (transform.right * x) + (transform.forward * z);// we want to move inthis direction

            velocity.y += gravity * Time.deltaTime;

            controller.Move((velocity + move) * speed * Time.deltaTime);
        }
        /// <summary>
        /// when you press E cast out a ray that will only hit interactable obj. if hits then Interact with that obj.
        /// </summary>
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
