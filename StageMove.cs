using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour
{
    public float stageSpeed = 2.0f;

    void Update()
    {
        //move the stage
        transform.Translate(Vector3.left * stageSpeed * Time.deltaTime);
    }
}
