using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        controller = GetComponent<CharacterController>();

        camera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
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
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

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

            ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

           
            int layerMask = LayerMask.NameToLayer("Interactable"); 

            layerMask = 1 << layerMask; 


            if (Physics.Raycast(ray, out hitInfo, 10f, layerMask))
            {

                if (hitInfo.collider.TryGetComponent<NPC>(out NPC npc))
                {
                    npc.Interact();
                }

                
            }


        }
    }

}