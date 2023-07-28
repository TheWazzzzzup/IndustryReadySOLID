using UnityEngine;

[CreateAssetMenu(menuName = "Data", fileName = nameof(IdentityData))]
public class IdentityData : ScriptableObject , IHoldData
{
    [SerializeField] string name;
    [SerializeField] int output;

    public string Name { get => name; }
    public int Output { get => output; }

}

public interface IHoldData
{
    public string Name { get; }
    public int Output { get; }

}