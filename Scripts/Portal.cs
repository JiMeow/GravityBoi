using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public void PortalActive()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Application.OpenURL("https://github.com/JiMeow");
            Sleep(2);
            Application.Quit();
        }
        Sleep(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Sleep(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
