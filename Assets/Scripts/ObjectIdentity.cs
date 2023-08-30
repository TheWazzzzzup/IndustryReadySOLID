using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIdentity : MonoBehaviour , IHoldIdentity
{
    [SerializeField] IdentityData identityData;

    public IHoldIdentityData DataHolder => identityData;
}

public interface IHoldIdentity
{
    public IHoldIdentityData DataHolder { get; }
}
