
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

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpDown();
        DropGift();

        //Debug.Log(string.Format("Score: {0}; Lives: {1}", score, lives));
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
