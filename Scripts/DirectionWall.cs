using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionWall : MonoBehaviour
{
    private Rigidbody2D player;
    private Text text;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float gravity = player.gravityScale;
        string tag = gameObject.tag;
        if (tag == "UpWall")
        {
            Debug.Log(gravity);
            if (gravity < 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (gravity > 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        if (tag == "DownWall")
        {
            if (gravity < 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            if (gravity > 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
