using UnityEngine;

//NOTE: used by both ball placer and Ball Combiner to spawn balls
public class SpawnBalls_Instance : MonoBehaviour
{
    public static SpawnBalls_Instance instance;
    PointUpdater_Instance PU;
    [SerializeField] BallList ballList;
    [SerializeField] GameObject Balls;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
        PU = PointUpdater_Instance.instance;
    }
//NOTE: pos = Vector3, level = ball type
    public void SpawnBalls(Vector3 pos, int level)
    {
        
        BallStats b = ballList.ballStats[level];
        PU.ScoreUpdate(b.pointsWhenSpawned);
        GameObject g = Instantiate(Balls, pos, Quaternion.identity);
        g.GetComponent<BallCombiner>().stats = ballList.ballStats[level];
        g.GetComponent<Rigidbody2D>().linearVelocityY = -0.2f;
        g.GetComponent<SpriteRenderer>().sprite = ballList.ballStats[level].sprite;
        g.transform.localScale = new Vector3(b.size, b.size, 0);
    }
}
