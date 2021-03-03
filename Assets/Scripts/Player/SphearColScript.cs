using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphearColScript : MonoBehaviour
{
    public List<GameObject> AIObjects;




    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AI"))
        {
            Debug.Log("AIDetected in sphere");
            AIObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AI"))
        {
            Debug.Log("AIGone in sphere");
            AIObjects.Remove(other.gameObject);
        }
    }

}
