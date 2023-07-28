using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

[RequireComponent(typeof(ICheckSurrounding))]
public class ObjectSurroundingSolver : MonoBehaviour , IHandleSurroundingInteractions
{
    ICheckSurrounding surroundingChecker;

    GameObject firstInteractedObject;

    private void Awake()
    {
        surroundingChecker = GetComponent<ICheckSurrounding>();
    }
    
    public void HandleSurroundingInteraction()
    {
        surroundingChecker.CheckSurroundings();
        if (surroundingChecker.surroundingGO.Count > 0)
        {
            firstInteractedObject = surroundingChecker.surroundingGO[0];
            if (firstInteractedObject.TryGetComponent<IHoldIdentity>(out IHoldIdentity identityHolder))
            {
                Debug.Log($"Hey my name is {identityHolder.DataHolder.Name}" +
                    $" , My output is {identityHolder.DataHolder.Output} units per sec");
            }
        }
    }

}

public interface IHandleSurroundingInteractions
{
    public void HandleSurroundingInteraction();
}
