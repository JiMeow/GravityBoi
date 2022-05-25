using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Blackhole : MonoBehaviour
{
    public float blackholeIncreaseSpeed = 2f;
    void Update()
    {
        Scaling();
    }

    void Scaling()
    {
        bool increse = false;
        if (Time.timeScale != 0)
        {
            if (((int)Time.time) % 2 == 0)
            {
                increse = true;
            }
            if (increse)
            {
                GetComponent<Transform>().localScale += new Vector3(blackholeIncreaseSpeed * Time.deltaTime, blackholeIncreaseSpeed * Time.deltaTime, blackholeIncreaseSpeed * Time.deltaTime);
            }
            else
            {
                GetComponent<Transform>().localScale -= new Vector3(blackholeIncreaseSpeed * Time.deltaTime, blackholeIncreaseSpeed * Time.deltaTime, blackholeIncreaseSpeed * Time.deltaTime);
            }
        }
    }

    public void BlackholeActive()
    {
        Invoke("RestartScene", 0.25f);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
