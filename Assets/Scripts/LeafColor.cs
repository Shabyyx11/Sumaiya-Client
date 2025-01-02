using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeafColor : MonoBehaviour
{ private Renderer rend;
    
    private bool isTriggerEntered = false;
    private float lerpTime = 0f;
    public float lerpSpeed = 1f;

    void Start()
    {
        // Get the renderer to access the material
        rend = GetComponent<Renderer>();
        rend.material.color =Color.grey;
    }

    void OnTriggerEnter(Collider other)
    {
        // When the trigger is entered, start color transition
        isTriggerEntered = true;
    }

    void Update()
    {
        // If the trigger event has occurred, lerp the color over time
        if (isTriggerEntered)
        {
            lerpTime += Time.deltaTime * lerpSpeed;

            // Lerp between startColor and endColor
            rend.material.color = Color.Lerp(rend.material.color= Color.grey,rend.material.color= Color.white,lerpTime);

            // Stop lerping once the transition is complete
            if (lerpTime >= 1f)
            {
                isTriggerEntered = false;  // Stop lerping after reaching the target color
            }
        }
    }
}
