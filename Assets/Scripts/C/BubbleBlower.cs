using UnityEngine;

public class BubbleBlower : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hi");
        BallCombiner b = collision.GetComponent<BallCombiner>();
        if (b != null)
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = -1;
        }
    }
}
