using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RainManager : MonoBehaviour
{

    public GameObject rain;
    public GameObject rainButton;
   

    public void RainActivation()
    {
        rain.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collided");
            rainButton.SetActive(true);
            this.gameObject.SetActive(false);
        }


    }

  
}
