using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private PlayerDetect playerDetect;
    [SerializeField] private SimplePlayerDetect playerDetect;

    private NavMeshAgent agent;

    
    public enum Mode
    {
        roaming,
        Chasing,
        Attacking,
    }
    public Mode mode;
    public bool destinationSet;

    private Coroutine tmpCor;


    [Header("PlayerAnimation")]
    public PlayerAnimConScript animConScript;


    [Header("Attack Scanner")]
    private float inputFreq;
    public float inputCheckFreq;
    public float inputLag;
    private float inputWaitTime;
    public AIAttackColScript attackColScript;


    [Header("AI Health")]
    public float health = 100;
    public float armor = 0;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        mode = Mode.roaming;
        inputFreq = 1.0f / inputCheckFreq;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player not detected
        if (mode == Mode.roaming)
        {
            if (!destinationSet)
            {
                SetRandomDestination();
                destinationSet = true;
            }
            if (playerDetect.playerInSight)
            {
                mode = Mode.Chasing;
                if (tmpCor != null)
                {
                    StopCoroutine(tmpCor);
                    tmpCor = null;
                }
            }
            if (agent.remainingDistance <= agent.stoppingDistance + 0.1f)
            {
                
                if(tmpCor == null)
                {
                    //Debug.LogError("asdasd");
                    tmpCor = StartCoroutine(LateGetRandomDestination());
                }
                
            }
        }
        //Player Detected and Going to Player
        else if (mode == Mode.Chasing)
        {
            
            agent.SetDestination(player.transform.position);
            if (agent.remainingDistance <= agent.stoppingDistance + 0.1f)
            {
                mode = Mode.Attacking;
            }
            if (Vector3.Distance(this.transform.position, player.transform.position) > 2f)
            {
                mode = Mode.roaming;
            }


        }
        //AttackMode
        else if (mode == Mode.Attacking)
        {
            LookAtPlayer();
            if(Vector3.Distance(this.transform.position,player.transform.position) > 1.2f)
            {
                mode = Mode.Chasing;
            }
            Attack();

        }
        else
        {
            mode = Mode.roaming;
        }
        

        


    }

    private void FixedUpdate()
    {
        if (inputWaitTime > 0)
        {
            inputWaitTime -= inputFreq;
        }
    }


    void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        direction.y = 0;
        Quaternion rotTarget = Quaternion.LookRotation(direction);

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, 500 * Time.deltaTime);


    }


    #region Getting Damage

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage " + damage);
        if (armor > 0)
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
        animConScript.GetHit1();


        inputWaitTime += inputLag;
        if(inputWaitTime > 5)
        {
            inputWaitTime = 2;
        }
    }

    #endregion




    #region AI Movement

    private void SetRandomDestination()
    {
        agent.SetDestination(GetRandomPoint(this.transform.position, 10f));
    }

    private Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);

        return hit.position;
    }


    IEnumerator LateGetRandomDestination()
    {
        yield return new WaitForSeconds(5f);
        tmpCor = null;
        destinationSet = false;
    }

    #endregion




    #region AI Attack

    public void Attack()
    {

        if (inputWaitTime <= 0)
        {
            Attack1();
            inputWaitTime += inputLag;
        }

    }


    private void Attack1()
    {
        // Play Animation
        if (Random.Range(0, 2) == 0)
        {
            animConScript.Punch1();
        }
        else
        {
            animConScript.Punch2();
        }

        StartCoroutine(DelayedAttack());

    }


    IEnumerator DelayedAttack()
    {
        yield return new WaitForSeconds(.15f);

        // Attack Detected Player
        // Attack Detected Player
        if (attackColScript.player != null)
        {
            attackColScript.player.GetComponent<PlayerController>().TakeDamage(5);
        }
    }


    #endregion


}
