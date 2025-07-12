using UnityEngine;

//NOTE: Universal Lose Call
public class WinLoseCall_Instance : MonoBehaviour
{
    public static WinLoseCall_Instance instance;
    bool lose = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        lose = false;
    }

    public void Lose()
    {
        if (lose == false)
        {
            lose = true;
            Debug.Log("lose");
        }
    }
}
