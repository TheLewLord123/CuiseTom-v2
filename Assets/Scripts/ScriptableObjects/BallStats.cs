using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "BallStats", menuName = "Scriptable Objects/BallStats")]
public class BallStats : ScriptableObject
{
    public int level = 0;
    public float size =1;
    public float pointsWhenAnihilated = 1;
}
