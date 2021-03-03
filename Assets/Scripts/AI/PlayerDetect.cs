using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private GameObject player;
   

    public bool playerInSight;
    private Vector3 localPlayerSighting;

    private void Awake()
    {
        playerInSight = false;
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerInSight == false)
        {
            if (other.gameObject == player)
            {
                playerInSight = true;
                localPlayerSighting = player.transform.position;
                Debug.Log("AI found Player");
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInSight = false;
            Debug.Log("AI Lost Player");
        }

    }


    private void DetectPlayer()
    {

    }



    private Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();


        return mesh;
    }



    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(this.transform.position, distance);

        //Vector3 fovline1 = Quaternion.AngleAxis(angle, this.transform.up) * this.transform.forward * distance;
        //Vector3 fovline2 = Quaternion.AngleAxis(-angle, this.transform.up) * this.transform.forward * distance;

        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(this.transform.position, fovline1);
        //Gizmos.DrawLine(this.transform.position, fovline2);
    }

}
