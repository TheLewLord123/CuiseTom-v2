using UnityEngine;
using UnityEngine.SceneManagement;

public class Trans : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(0);
    }
}
