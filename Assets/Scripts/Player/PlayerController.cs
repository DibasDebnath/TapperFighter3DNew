using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Health")]
    public float health = 100;
    public float armor = 0;

    
    [Header("PlayerMovement")]
    public float speed = 1f;
    public float turnSmoothTime = 0.08f;
    public Transform camTransform;
    public CharacterController characterController;
    float turnSmoothVelocity;
    public bool isMoving;


    [Header("PlayerAnimation")]
    public PlayerAnimConScript animConScript;


    [Header("Detectors")]
    public SphearColScript sphearCol;
    public AttackColScript attackCol;



    [Header("Attack Scanner")]
    private float inputFreq;
    public float inputCheckFreq;
    public float inputLag;
    private float inputWaitTime;
    


    private void Awake()
    {
        if(characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
        inputFreq = 1.0f / inputCheckFreq;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LookAtAI();
        //Debug.Log(joystick.Horizontal);
        if (RefHolder.instance.inputController.horizontal !=0f && RefHolder.instance.inputController.vertical != 0f)
        {
            isMoving = true;
            movePlayer(RefHolder.instance.inputController.horizontal, RefHolder.instance.inputController.vertical);
            animConScript.playerMovement(RefHolder.instance.inputController.horizontal, RefHolder.instance.inputController.vertical);
        }
        else
        {
            isMoving = false;
            animConScript.playerMovement(0, 0);
            LookAtAI();
        }
        
        
    }

    private void FixedUpdate()
    {
        if(inputWaitTime > 0)
        {
            inputWaitTime -= inputFreq;
        }
    }


    #region Player Movement

    void movePlayer(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if(direction.magnitude >= 0.01f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            if (sphearCol.AIObjects.Count > 0)
            {
                characterController.Move(moveDirection * speed * Time.deltaTime);
            }
            else
            {
                characterController.Move(moveDirection * speed * 2 * Time.deltaTime);
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
        animConScript.PlayPunch1();

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



        inputWaitTime += inputLag;

    }

    private void GetDamage1()
    {
        
    }


    #endregion



}
