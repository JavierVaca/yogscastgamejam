
using System;
using UnityEngine;
using UnityEngine.UI;

public class Santa : MonoBehaviour
{
    public KeyCode dropButton   = KeyCode.Space;
    public KeyCode pullUp       = KeyCode.UpArrow;
    public KeyCode pushDown     = KeyCode.DownArrow;

    public float altitudeSpeed;
    public int score = 0;
    public int lives = 5;
    public Text scoreText;
    public Text livesText;

    Rigidbody2D rigid;
    Animator animator;
    private Vector2 startPosition;
    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpDown();
        DropGift();
        CheckGameOver();
        scoreText.text = "Score: " + score;
    }

    private void CheckGameOver()
    {
        if (lives <= 0)
        {

        }
    }

    // Up and Down Controls
    void MoveUpDown()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        Vector2 position = rigid.position;

        position = position + move * altitudeSpeed * Time.deltaTime;

        rigid.MovePosition(position);
    }

    // Gift Drop Control
    void DropGift()
    {
        if (Input.GetKeyDown(dropButton))
        {
            var gift = Instantiate(
                (GameObject)Resources.Load("Prefabs/Gift"),
                transform.position - new Vector3(0.5f, 0.35f, 0),
                Quaternion.identity
            );

            var spriteR = gift.GetComponent<SpriteRenderer>();
            Sprite[] sprites = Resources.LoadAll<Sprite>("Art/gifts");
            spriteR.sprite = sprites[UnityEngine.Random.Range(0, 4)];
        }
    }

    public void Dead()
    {
        Invoke("ResetPosition", 1f);
        dead = true;
        animator.SetBool("dead", dead);
        livesText.text = "Lives: " + lives;
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
        dead = false;
        animator.SetBool("dead", dead);
    }
}
