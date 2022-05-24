using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    void Update()
    {
        Transform wallTransfrom = GetComponent<Transform>();
        Debug.Log(wallTransfrom.position.x);
        if (wallTransfrom.position.x < -25)
        {
            wallTransfrom.position = new Vector3(-30, wallTransfrom.position.y, wallTransfrom.position.z);
        }
    }
}
