using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    bool gameTextStart = false;
    bool gameTextStartComplete = false;
    bool isGrounded;
    public float playerSpeed = 2.0f;
    public float playerHeight = 1.0f;


    public StageMove stageMove;
    private int gravity = 1;
    private Vector3 playerOriginalPosition;
    private Rigidbody2D rb;



    Transform startTextTransfrom;
    Vector3 goal;

    void Start()
    {
        Time.timeScale = 0;
        isGrounded = true;

        playerOriginalPosition = GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody2D>();

        startTextTransfrom = GameObject.Find("StartText").GetComponent<Transform>();
        goal = startTextTransfrom.position + new Vector3(0, 1, 0);
    }

    void StartGame()
    {
        gameTextStart = true;
        startTextTransfrom.position = Vector3.MoveTowards(startTextTransfrom.position, goal, 0.01f);
        if (startTextTransfrom.position == goal)
        {
            gameTextStart = false;
            Time.timeScale = 1;
            gameTextStartComplete = true;
        }
    }


    void Update()
    {
        //press Enter to start the game
        if (Input.GetKeyDown("return") || gameTextStart)
        {
            if (gameTextStartComplete == false)
            {
                StartGame();
            }
        }

        //press escape to quit the game
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        //if player not in start position player run
        if (Mathf.Round(gameObject.transform.position.x) != Mathf.Round(playerOriginalPosition.x))
            MoveForward();

        //change isOnGrounded to true if player is on the ground
        OnGrounded();

        //if player is on the ground and press space, player jump
        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();

        //Reset the player to the start position
        isDead();
    }

    void MoveForward()
    {
        gameObject.transform.position += new Vector3(
                Mathf.Min(playerOriginalPosition.x - gameObject.transform.position.x, playerSpeed * Time.deltaTime), 0, 0);
    }

    void Jump()
    {
        gravity *= -1;
        isGrounded = false;
        GetComponent<Rigidbody2D>().gravityScale *= -1;
    }

    void OnGrounded()
    {
        if (gravity > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, playerHeight / 2.0f + 0.1f);
            if (hit.collider != null)
            {
                isGrounded = true;
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, playerHeight / 2.0f + 0.1f);
            if (hit.collider != null)
            {
                isGrounded = true;
            }
        }

    }

    void isDead()
    {
        if (gameObject.transform.position.x < -26)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Portal")
        {
            other.gameObject.GetComponent<Portal>().PortalActive();
        }
        if (other.gameObject.tag == "Lava")
        {
            other.gameObject.GetComponent<Lava>().LavaActive();
        }
        if (other.gameObject.tag == "Npc")
        {
            DialogueTrigger dialogueTrigger = other.gameObject.GetComponent<DialogueTrigger>();
            dialogueTrigger.TriggerDialogue();
            stageMove.Pause();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Blackhole")
        {
            other.gameObject.GetComponent<Blackhole>().BlackholeActive();
        }
    }
}
