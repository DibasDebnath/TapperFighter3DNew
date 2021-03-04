using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{


    Controller inputAction;
    [Header("Take Input")]
    public bool takeInput;


    //Private Variables
    private bool tap;
    private bool processedTap;
    bool move;
    float moveDisplacement;
    private Vector2 screenTouchPosition;
    Vector2 currentTouchPosition;
    Vector2 oldTouchPosition;

    [Header("Joystick")]
    public Joystick joystick;
    public float horizontal;
    public float vertical;

    private void Awake()
    {
        
        inputAction = new Controller();
        inputAction.Player.TouchStart.performed += ctx => TouchStart();
        inputAction.Player.TouchEnd.performed += ctx => TouchEnd();
        inputAction.Player.TouchMove.performed += ctx => screenTouchPosition = ctx.ReadValue<Vector2>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (takeInput)
        {
            getJoysticInput();
        }
        
    }


    void TouchStart()
    {
        if (takeInput)
        {
            Debug.Log("Tap Start");
        }
        
    }
    void TouchEnd()
    {
        if (takeInput)
        {
            Debug.Log("Tap End");
            RefHolder.instance.playerController.Attack();
        }
           
    }

    void getJoysticInput()
    {
        horizontal = joystick.Direction.x;
        vertical = joystick.Direction.y;
    }






    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}
