using System;
using UnityEngine;

public class DesiredGoalBalls_Instance : MonoBehaviour
{
    public static DesiredGoalBalls_Instance instance;
    public BallCombiner[] balls;
    public GoalAndCount[] goalAndCount;
    WinLoseCall_Instance WLC;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    void Start()
    {
        WLC = WinLoseCall_Instance.instance;
    }
    void Update()
    {
        balls = GameObject.FindObjectsByType<BallCombiner>(FindObjectsSortMode.None);
        int i = 0;
        foreach (BallCombiner ballLevel in balls)
        {
            if (ballLevel.stats.level == goalAndCount[PublicInventory.currentLevel].level)
            {
                Rigidbody2D rigid = ballLevel.GetComponent<Rigidbody2D>();
                if (Mathf.Abs(rigid.linearVelocity.x) < 0.1f && Mathf.Abs(rigid.linearVelocity.y) < 0.1f)
                {
                    i++;
                }
            }
        }
        if (i >= goalAndCount[PublicInventory.currentLevel].count)
        {
            PublicInventory.currentLevel++;
            WLC.Win();
        }
    }
}
[Serializable]
public class GoalAndCount
{
    public int level, count;
}