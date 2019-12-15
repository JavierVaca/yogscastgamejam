
using UnityEngine;

public class Chimney : MonoBehaviour
{
    public GameObject ChimneyTop;

    private ChimneySpawner spawner;
    
    public Santa santa;

    // Randomize height and position top
    // at start.
    void Start()
    {
        BoxCollider2D chimneyCollide = GetComponent<BoxCollider2D>();

        float newHeight = Random.Range(0.15f, 1f) * 4.5f;

        chimneyCollide.size = new Vector2(1f, newHeight);
        chimneyCollide.offset = Vector2.up * newHeight/2;

        ChimneyTop.GetComponent<Transform>().localPosition = Vector3.up * (newHeight+0.25f);

        // Set santa to player
        santa = GameObject.FindGameObjectWithTag("Player").GetComponent<Santa>();

        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ChimneySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        // Delete chimney once off stage...
        if (transform.position.x <= -10f)
        {
            Destroy(gameObject);
        }
    }

    // Chimney moves from right to left of the screen.
    void Move()
    {
        transform.Translate(Time.deltaTime * Vector3.left * spawner.chimneySpeed, Space.Self);
    }
}
