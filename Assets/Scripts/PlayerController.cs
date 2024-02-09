using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float Speed = 10f;
    float startSpeed = 0;

        CharacterController characterController;
   
    // Start is called before the first frame update

    public Transform groundCheck;
    public LayerMask groundMask;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        startSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        RaycastHit hit;

        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 1f,groundMask))
        {
            switch (hit.collider.gameObject.tag)
            {
                default:
                    Speed = startSpeed;
                    break;
                case "LowSpeed":
                    Speed = startSpeed / 2;
                    break;
                case "HighSpeed":

                    Speed = startSpeed * 2;
                    break;

            }

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move*Speed*Time.deltaTime);
        //print(x);//
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
