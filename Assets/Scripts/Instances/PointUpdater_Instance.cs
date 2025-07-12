using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PointUpdater_Instance : MonoBehaviour
{
    public static PointUpdater_Instance instance;
    int score;
    [SerializeField] TextMeshProUGUI Score;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
        score = 0;
        Score.text = score.ToString();
    }
    public void ScoreUpdate(int s)
    {
        score += s;
        Score.text = score.ToString();
    }

}
