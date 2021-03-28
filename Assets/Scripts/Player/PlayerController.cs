using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [Header("Player Health")]
    public float health = 100;
    public float armor = 0;
   
    
    [Header("PlayerMovement")]
    [SerializeField] public float topSpeed = 1f;
    [SerializeField] float acceleration = 0.2f;
    [SerializeField] float turnSmoothTime = 0.08f;
    [SerializeField] Transform camTransform;
    CharacterController characterController;
    float turnSmoothVelocity;
    bool isMoving;
    float speed = 0f;

    [Header("Player Gravity")]
    [SerializeField] float gravity;
    float currentGravity;
    [SerializeField] float constantGravity;
    [SerializeField] float maxGravity;

    Vector3 gravityDirection;
    Vector3 gravityMovement;


    [Header("PlayerAnimation")]
    //[SerializeField] PlayerAnimConScript animConScript;
    [HideInInspector] public UnityEvent onAttack;
    [HideInInspector] public UnityEvent onIdle;
    [HideInInspector] public UnityEvent onFistIdle;
    [HideInInspector] public UnityEvent<float,float> onWalk;
    [HideInInspector] public UnityEvent onRun;
    [HideInInspector] public UnityEvent onHit;
    


    [Header("Detectors")]
    [SerializeField] SphearColScript sphearCol;
    [SerializeField] AttackColScript attackCol;


    [Header("Attack Scanner")]
    float inputFreq;
    [SerializeField] float inputCheckFreq;
    [SerializeField] float inputLag;
    float inputWaitTime;
    

    private void Awake()
    {
        if(characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
        inputFreq = 1.0f / inputCheckFreq;
        gravityDirection = -Vector3.down;

        
        // calculate the correct vertical position:
        float correctHeight = characterController.center.y + characterController.skinWidth;
        // set the controller center vector:
        characterController.center = new Vector3(0, correctHeight, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calculateGravity();
        //Debug.Log(joystick.Horizontal);
        if (RefHolder.instance.inputController.horizontal !=0f && RefHolder.instance.inputController.vertical != 0f)
        {
            if(inputWaitTime <= 0)
            {
                isMoving = true;
                movePlayer(RefHolder.instance.inputController.horizontal, RefHolder.instance.inputController.vertical);
            }
           
            
        }
        else
        {
            isMoving = false;
            //animConScript.Idle();
            if (sphearCol.AIObjects.Count > 0)
            {
                onFistIdle?.Invoke();
            }
            else
            {
                onIdle?.Invoke();
            }
                
            LookAtAI();
        }
        
        
    }

    private void FixedUpdate()
    {
        if(inputWaitTime > 0)
        {
            inputWaitTime -= inputFreq;
        }
        if (isMoving)
        {
            SpeedIncreaser();
        }
        else
        {
            speed = 0f;
        }
    }


    #region Player Movement


    void SpeedIncreaser()
    {
        speed += acceleration;
        if(speed > topSpeed)
        {
            speed = topSpeed;
        }
    }

    void movePlayer(float horizontal, float vertical)
    {
        if(inputWaitTime <= 0)
        {
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
            if (direction.magnitude >= 0.01f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
                if (sphearCol.AIObjects.Count > 0)
                {
                    LookAtAI();
                }
                else
                {
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }
                
                Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                if (sphearCol.AIObjects.Count > 0)
                {
                    characterController.Move(gravityMovement+ moveDirection * speed * 0.5f * Time.deltaTime);
                    //animConScript.Walk();
                    float angle = Vector3.Angle(this.transform.forward , moveDirection);
                    Vector3 cross = Vector3.Cross(this.transform.forward, moveDirection);
                    if (cross.y < 0) angle = -angle;
                    //Debug.Log(angle);
                    onWalk.Invoke(speed,angle);
                }
                else
                {
                    characterController.Move(gravityMovement + moveDirection * speed * 1.5f * Time.deltaTime);
                    //animConScript.Run();
                    onRun.Invoke();
                }
                
            }
        }
        
        //characterController.ho
    }
    void LookAtAI()
    {
        if(sphearCol.AIObjects.Count > 0)
        {
            Vector3 direction = sphearCol.AIObjects[0].transform.position - this.transform.position;
            direction.y = 0;
            Quaternion rotTarget = Quaternion.LookRotation(direction);

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, 500 * Time.deltaTime);
        }
    }

    #endregion



    #region Gravity


    private bool IsGrounded()
    {
        return characterController.isGrounded;
    }
    private void calculateGravity()
    {
        if (IsGrounded())
        {
            currentGravity = constantGravity;
        }
        else
        {
            if(currentGravity > maxGravity)
            {
                currentGravity -= gravity * Time.deltaTime;
            }
        }
        gravityMovement = gravityDirection * currentGravity;
    }

    #endregion



    #region Player Attack

    public void Attack()
    {
        
        if(inputWaitTime <= 0)
        {
            Attack1();
            inputWaitTime += inputLag;
        }
        
    }


    private void Attack1()
    {
        // Play Animation
        onAttack.Invoke();

        StartCoroutine(DelayedAttack());
       
    }

    IEnumerator DelayedAttack()
    {
        yield return new WaitForSeconds(.15f);

        // Attack Detected Player
        if (attackCol.AIObjects.Count > 0)
        {
            foreach (GameObject G in attackCol.AIObjects)
            {
                G.transform.GetComponent<AIController>().TakeDamage(5);
            }
        }
    }


    #endregion


    #region Take Damage

    public void TakeDamage(float damage)
    {
        if(armor > 0)
        {
            armor -= damage;
            if (armor <= 0)
            {
                armor = 0;
            }
        }
        else
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                // Die
            }
        }

        //Play Animation
        //animConScript.GetHit1();
        onHit.Invoke();


        inputWaitTime += inputLag;

    }

    private void GetDamage1()
    {
        
    }


    #endregion



}
