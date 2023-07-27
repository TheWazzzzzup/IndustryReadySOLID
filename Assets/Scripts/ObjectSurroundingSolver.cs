using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ICheckSurrounding))]
public class ObjectSurroundingSolver : MonoBehaviour , IHandleSurroundingInteractions
{
    ICheckSurrounding surroundingChecker;
  
    private void Awake()
    {
        surroundingChecker = GetComponent<ICheckSurrounding>();
    }
    
    public void HandleSurroundingInteraction()
    {
        surroundingChecker.CheckSurroundings();
        foreach (GameObject go in surroundingChecker.surroundingGO)
        {
            // Add Action to the game object
        }
    }

}

public interface IHandleSurroundingInteractions
{
    public void HandleSurroundingInteraction();
}
