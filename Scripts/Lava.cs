using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Lava : MonoBehaviour
{
    // Start is called before the first frame update
    public void LavaActive()
    {
        Sleep(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Sleep(int seconds) 
    {
        yield return new WaitForSeconds(seconds);
    }
}
