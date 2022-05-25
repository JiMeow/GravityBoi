using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour
{
    public float stageSpeed = 2.0f;

    void Update()
    {
        transform.Translate(Vector3.left * stageSpeed * Time.deltaTime);
    }

    public void Pause()
    {
        stageSpeed = 0f;
    }

    public void Continue()
    {
        stageSpeed = 2f;
    }
}
