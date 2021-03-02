using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetect : MonoBehaviour
{
    public List<GameObject> AIObjects;




    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AI"))
        {
            Debug.Log("AIDetected");
            AIObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AI"))
        {
            Debug.Log("AIGone");
            AIObjects.Remove(other.gameObject);
        }
    }

}
