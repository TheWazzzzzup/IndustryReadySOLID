using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSphereSurroundings : MonoBehaviour , ICheckSurrounding
{
    [SerializeField] float radius;
    [SerializeField] LayerMask targetMask;

    Collider[] surroundingsColliders;

    List<GameObject> availableObjects = new();

    List<GameObject> ICheckSurrounding.surroundingGO { get => availableObjects; }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void ICheckSurrounding.CheckSurroundings()
    {
        surroundingsColliders = Physics.OverlapSphere(transform.position, radius, targetMask);
        availableObjects.Clear();

        if (surroundingsColliders.Length > 0)
        {
            foreach (Collider c in surroundingsColliders)
            {
                availableObjects.Add(c.gameObject); 
                Debug.DrawLine(transform.position, c.transform.position);
            }
        }
    }
}
