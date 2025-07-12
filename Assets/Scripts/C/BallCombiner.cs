using UnityEditor.Analytics;
using UnityEngine;

public class BallCombiner : MonoBehaviour
{
    private int Balllayer;
    public BallStats stats;
    SpawnBalls_Instance SB; PointUpdater_Instance PU;
    void Start()
    {
        Balllayer = LayerMask.GetMask("Balls");
        SB = SpawnBalls_Instance.instance;
        PU = PointUpdater_Instance.instance;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (1 << other.gameObject.layer == Balllayer)
        {
            BallCombiner b = other.gameObject.GetComponent<BallCombiner>();
            if (b != null)
            {
                if (b.stats.level == stats.level)
                {
                    int thisID = gameObject.GetInstanceID();
                    int otherID = other.gameObject.GetInstanceID();
                    if (thisID > otherID)
                    {
                        Vector3 middlePosition = (transform.position + other.transform.position) * 0.5f;
                        SB.SpawnBalls(middlePosition, stats.level + 1);
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
