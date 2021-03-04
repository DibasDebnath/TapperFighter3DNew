using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerDetect : MonoBehaviour
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

    private void OnTriggerStay(Collider other)
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
}
