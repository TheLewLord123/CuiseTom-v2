using UnityEngine;


public class TopLine_Instance : MonoBehaviour
{
    WinLoseCall_Instance WLC;
    void Start()
    {
        WLC = WinLoseCall_Instance.instance;
    }
    //NOTE: when ball crosses the line without momentum
    void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D h = collision.GetComponent<Rigidbody2D>();
        if (Mathf.Abs(h.linearVelocity.x) < 0.1f && Mathf.Abs(h.linearVelocity.y) < 0.1f)
        {
            WLC.Lose();
        }
    }
}
