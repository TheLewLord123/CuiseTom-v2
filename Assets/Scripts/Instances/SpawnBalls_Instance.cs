using UnityEngine;

//NOTE: used by both ball placer and Ball Combiner to spawn balls
public class SpawnBalls_Instance : MonoBehaviour
{
    public static SpawnBalls_Instance instance;
    [SerializeField] BallStats[] defaultStats;
    [SerializeField] GameObject Balls;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
//NOTE: pos = Vector3, level = ball type
    public void SpawnBalls(Vector3 pos, int level)
    {
        BallStats b = defaultStats[0];

        GameObject g = Instantiate(Balls, pos, Quaternion.identity);
        g.GetComponent<BallCombiner>().stats = defaultStats[level];
        
    }
}
