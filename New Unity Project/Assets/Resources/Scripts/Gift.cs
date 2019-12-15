
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
            santa.score--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "chimney")
        {
            santa.score++;

            if (santa.score != 0 && santa.score % 20 == 0)
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
