using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerOriginalPosition;
    public float playerSpeed = 2.0f;
    void Start()
    {
        playerOriginalPosition = GetComponent<Transform>().position;
    }
    void Update()
    {
        if (Mathf.Round(gameObject.transform.position.x) != Mathf.Round(playerOriginalPosition.x))
        {
            Debug.Log("Player is moving");
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                                                                playerOriginalPosition, playerSpeed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            //reverse garvity
            GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
    }
}
