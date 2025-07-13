using System.Collections;
using UnityEngine;

public class StrawBlower_Instance : MonoBehaviour
{
    public static StrawBlower_Instance instance;
    [SerializeField] GameObject straw, strawCollider;
    int repeats;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);

        straw.SetActive(false);
        strawCollider.SetActive(false);
        StartCoroutine(timer(1.0f));
    }

    public void SummonStraw()
    {
        straw.SetActive(true);
        StartCoroutine(timer(1.0f));
    }
    IEnumerator timer(float time)
    {
        Debug.Log(time);
        
        time -= 0.1f;
        if (time < 0.1f)
            time = 0.1f;
        yield return new WaitForSeconds(time);
        StartCoroutine(timer(time));
    }
}
