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

    public float JumpPower = 10;
    private Vector3 playerVelocity;
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

        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.5f,groundMask))
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

        playerVelocity += Physics.gravity * Time.deltaTime  * 2;




        Vector3 move = hit.collider != null? (transform.right * x + transform.forward * z + transform.up * playerVelocity.y ) : transform.up * playerVelocity.y ;



        playerVelocity.y = Input.GetKeyDown(KeyCode.Space) && hit.collider != null ? JumpPower : 0;
        
        
        
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
