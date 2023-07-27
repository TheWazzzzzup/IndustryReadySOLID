using System.Collections.Generic;
using UnityEngine;

public interface ICheckSurrounding
{
    List<GameObject> surroundingGO { get; }

    void CheckSurroundings();
}