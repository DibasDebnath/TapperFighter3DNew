using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{


    Controller inputAction;

    //Private Variables
    public bool tap;
    private bool processedTap;
    bool move;
    float moveDisplacement;
    public Vector2 screenTouchPosition;
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
        getJoysticInput();
    }


    void TouchStart()
    {
        Debug.Log("Tap Start");
    }
    void TouchEnd()
    {
        Debug.Log("Tap End");
        RefHolder.instance.playerController.Attack();
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
