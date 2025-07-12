using UnityEngine;

public class BallCombiner : MonoBehaviour
{
    private int Balllayer;
    public BallStats stats;
    void Start()
    {
        Balllayer = LayerMask.GetMask("Balls");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (1 << other.gameObject.layer == Balllayer)
        {
            BallCombiner b = other.gameObject.GetComponent<BallCombiner>();
            if (b != null)
            {
                int thisID = gameObject.GetInstanceID();
            }
        }

    }
}
