using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("PlayerMovement")]
    //public Variables;
    public float speed = 1f;
    public float turnSmoothTime = 0.08f;
    public Transform camTransform;
    public CharacterController characterController;
    //private Variables;
    float turnSmoothVelocity;
    [Header("PlayerAnimation")]
    public PlayerAnimationControllerScript playerAnimConScript;



    
    

    private void Awake()
    {
        if(characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
        
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(joystick.Horizontal);
        if(RefHolder.instance.inputController.horizontal !=0f && RefHolder.instance.inputController.vertical != 0f)
        {
            movePlayer(RefHolder.instance.inputController.horizontal, RefHolder.instance.inputController.vertical);
            playerAnimConScript.playerMovement(RefHolder.instance.inputController.horizontal, RefHolder.instance.inputController.vertical);
        }
        else
        {
            playerAnimConScript.playerMovement(0, 0);
        }
        
    }




    void movePlayer(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            characterController.Move(moveDirection * speed * Time.deltaTime);
            
        }
        //characterController.ho
    }
    void rotatePlayer()
    {

    }


    public void Attack()
    {
        playerAnimConScript.PlayPunch1();
    }

    
    
}
