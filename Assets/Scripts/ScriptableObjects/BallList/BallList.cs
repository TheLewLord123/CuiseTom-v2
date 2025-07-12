using UnityEngine;

[CreateAssetMenu(fileName = "BallList", menuName = "Scriptable Objects/BallList")]
public class BallList : ScriptableObject
{
    public BallStats[] ballStats;
}
