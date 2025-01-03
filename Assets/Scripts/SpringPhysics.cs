using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPhysics : MonoBehaviour
{


    private Rigidbody rb;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }
    public void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the one you want to interact with
        if (other.CompareTag("Spring"))  // Example: You can check for a specific tag like "Player"
        {
            Debug.Log("Spring");
            ApplyUpwardImpulse();
        }
    }

    void ApplyUpwardImpulse()
    {


        // Apply the force using ForceMode.Impulse for an instantaneous change in velocity
        rb.AddForce(new Vector3(0, 1000, 0), ForceMode.Impulse);
    }
}
