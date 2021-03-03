using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColScript : MonoBehaviour
{
    public List<GameObject> AIObjects;


    

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AI"))
        {
            Debug.Log("AIDetected in Attack");
            AIObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AI"))
        {
            Debug.Log("AIGone in Attack");
            AIObjects.Remove(other.gameObject);
        }
    }

}
