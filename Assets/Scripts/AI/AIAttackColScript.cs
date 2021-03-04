using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackColScript : MonoBehaviour
{
    public GameObject player;




    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in Attack");
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Gone in Attack");
            player = other.gameObject;
        }
    }
}
