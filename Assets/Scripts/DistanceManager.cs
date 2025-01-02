using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    [Header("References")]
    public Transform mainPlayer; 
    public Transform endPoint;  

    [Header("UI Components")]
    public Image distanceFillImage; 

    private float maxDistance; 

    void Start()
    {
        if (mainPlayer != null && endPoint != null)
        {
            maxDistance = Vector3.Distance(mainPlayer.position, endPoint.position);
        }
    }

    void Update()
    {
        if (mainPlayer != null && endPoint != null && distanceFillImage != null)
        {
            float currentDistance = Vector3.Distance(mainPlayer.position, endPoint.position);
            float fillAmount = Mathf.Clamp01(1 - (currentDistance / maxDistance));
            distanceFillImage.fillAmount = fillAmount;
        }
        else
        {
            Debug.LogError("Ensure all references are assigned correctly.");
        }
    }


}
