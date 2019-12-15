
using UnityEngine;

public class Chimney : MonoBehaviour
{
    public float chimneySpeed = 10f;

    public GameObject ChimneyTop;
    private ChimneySpawner spawner;



    // Randomize height and position top
    // at start.
    void Start()
    {
        //BoxCollider2D chimneyCollide = GetComponent<BoxCollider2D>();

        //float newHeight = Random.Range(0.15f, 1f) * 4.5f;

        //chimneyCollide.size = new Vector2(1f, newHeight);
        //chimneyCollide.offset = Vector2.up * newHeight/2;

        //ChimneyTop.GetComponent<Transform>().localPosition = Vector3.up * newHeight;
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<ChimneySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        // Delete chimney once off stage...
        if (transform.position.x <= -8f)
        {
            Destroy(gameObject);
        }
    }

    // Chimney moves from right to left of the screen.
    void Move()
    {
        transform.Translate(Time.deltaTime * Vector3.left * spawner.chimneySpeed, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Santa player = collision.gameObject.GetComponent<Santa>();
            player.Dead();
        }
    }
}
