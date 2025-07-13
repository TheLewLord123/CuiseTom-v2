using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsScript : MonoBehaviour
{
    public Animator transition;

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public IEnumerator Load(int BuildIndex)
    //{
    //    transition.SetTrigger("SceneTransition");
    //    yield return new WaitForSecondsRealtime(2f);
    //    SceneManager.LoadScene(BuildIndex);
    //}
}
