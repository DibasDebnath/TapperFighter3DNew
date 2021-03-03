using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerDetect playerDetect;

    private NavMeshAgent agent;

    [Header("AI Modes")]
    // 0 = Roaming
    // 1 = Going to Player
    // 2 = Attacking
    public int currentMode;
    public bool destinationSet;

    private Coroutine tmpCor;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        currentMode = 0;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player not detected
        if (currentMode == 0)
        {
            if (!destinationSet)
            {
                SetRandomDestination();
                destinationSet = true;
            }
            if (agent.remainingDistance <= agent.stoppingDistance + 0.1f)
            {
                
                if(tmpCor == null)
                {
                    Debug.LogError("asdasd");
                    tmpCor = StartCoroutine(LateGetRandomDestination());
                }
                
            }
        }
        //Player Detected and GOing to Player
        if (playerDetect.playerInSight)
        {
            currentMode = 1;
            if (tmpCor != null)
            {
                StopCoroutine(tmpCor);
                tmpCor = null;
            }
            agent.SetDestination(player.transform.position);
            if (agent.remainingDistance <= agent.stoppingDistance + 0.1f)
            {
                currentMode = 2;
            }
            else
            {
                currentMode = 1;
            }

        }
        else
        {
            currentMode = 0;
        }
        
        //AttackMode
        if(currentMode == 2)
        {

        }
        

        


    }





    #region Getting Damage

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage " + damage);
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


  

}