using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIdentity : MonoBehaviour , IHoldIdentity
{
    [SerializeField] IdentityData identityData;

    public IHoldData DataHolder => identityData;
}

public interface IHoldIdentity
{
    public IHoldData DataHolder { get; }
}
