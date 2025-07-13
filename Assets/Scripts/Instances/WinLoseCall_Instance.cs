using UnityEngine;
using UnityEngine.SceneManagement;
//NOTE: Universal Lose Call
public class WinLoseCall_Instance : MonoBehaviour
{
    public static WinLoseCall_Instance instance;
    bool lose = false, win = false;
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
        win = false;
    }

    public void Lose()
    {
        if (lose == false)
        {
            lose = true;
            SceneManager.LoadScene("xxLose");
        }
    }
    public void Win()
    {
        if (win == false)
        {
            win = true;
            SceneManager.LoadScene("xxWin");
        }
    }
}
