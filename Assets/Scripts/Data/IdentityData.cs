using UnityEngine;

[CreateAssetMenu(fileName = nameof(IdentityData))]
public class IdentityData : ScriptableObject , IHoldIdentityData
{
    [SerializeField] string name;
    [SerializeField] int output;

    public string Name { get => name; }
    public int Output { get => output; }

}
