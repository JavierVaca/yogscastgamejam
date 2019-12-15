
using UnityEngine;

public class Gift : MonoBehaviour
{
    public Santa santa;
    public ChimneySpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        // Set santa to player.
        santa = GameObject.FindGameObjectWithTag("Player").GetComponent<Santa>();

        // Set the chimney spawner to spawner
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<ChimneySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // Delete gift if below threshold...
        if (transform.position.y < -4)
        {
            Destroy(gameObject);
            Santa.score--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "chimney")
        {
            Santa.score++;

            if (Santa.score != 0 && Santa.score % 20 == 0)
            {
                spawner.chimneySpeed++;
            }
            Destroy(gameObject);
            Instantiate(
                 (GameObject)Resources.Load("Prefabs/Firework"),
                 transform.position,
                 Quaternion.identity
            );
        }
    }
}
