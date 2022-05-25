using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Lava : MonoBehaviour
{
    // Start is called before the first frame update
    public void LavaActive()
    {
        Invoke("RestartScene", 0.25f);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
