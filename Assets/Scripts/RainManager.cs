using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnvoManager : MonoBehaviour
{

    public GameObject rain;
    public GameObject rainButton;
    public GameObject RainCloud;
   

    public void RainActivation()
    {
        rain.SetActive(true);
        rainButton.SetActive(false);
        StartCoroutine(Raincloud());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collided");
            rainButton.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().enabled=false;
        }


    }
    IEnumerator Raincloud(){
        RainCloud.SetActive(true);
        yield return new WaitForSeconds(10f);
        rain.SetActive(false);
        RainCloud.SetActive(false);
    }
  
}
