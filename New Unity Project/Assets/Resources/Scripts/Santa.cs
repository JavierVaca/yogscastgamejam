
using UnityEngine;

public class Santa : MonoBehaviour
{
    public KeyCode dropButton   = KeyCode.Space;
    public KeyCode pullUp       = KeyCode.UpArrow;
    public KeyCode pushDown     = KeyCode.DownArrow;

    public float altitudeSpeed;

    Rigidbody2D rigid;

    public int score = 0;

    public int lives = 5;

    public GameUI gameUI;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 5;

        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameUI.isGameOver == false)
        {
            MoveUpDown();
            DropGift();
        }

        if (lives <= 0)
        {
            gameUI.isGameOver = true;
        }
    }

    void OnCollisionEnter2D()
    {
        lives--;
    }

    // Up and Down Controls
    void MoveUpDown()
    {
        if (Input.GetKey(pullUp))
        {
            rigid.velocity = Vector2.up * altitudeSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(pushDown))
        {
            rigid.velocity = Vector2.down * altitudeSpeed * Time.deltaTime;
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }

    // Gift Drop Control
    void DropGift()
    {
        if (Input.GetKeyDown(dropButton))
        {
            GameObject newGift = (GameObject)Resources.Load("Prefabs/Gift");

            Instantiate(
                newGift,
                transform.position - new Vector3(0.5f, 0.35f, 0),
                Quaternion.identity
            );
        }
    }
}
