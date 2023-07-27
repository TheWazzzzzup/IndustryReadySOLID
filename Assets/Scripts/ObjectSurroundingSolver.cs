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
        // Todo : enter logic of the player
    }

}

public interface IHandleSurroundingInteractions
{
    public void HandleSurroundingInteraction();
}
