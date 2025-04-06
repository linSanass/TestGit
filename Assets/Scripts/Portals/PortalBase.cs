using UnityEngine;

public class PortalBase : MonoBehaviour
{
    public Transform targetPortal;
    public float detectionRadius = 1f;

    protected void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                virMethod(collider.transform);
            }
        }
    }
    protected virtual void virMethod(Transform obj)
    {
        obj.position = targetPortal.position;
    }
}