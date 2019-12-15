
using UnityEngine;

public class Gift : MonoBehaviour
{
    // The instantiated player Santa object
    public Santa santa;
    public ChimneySpawner spawner;


    void Start()
    {
        // Set santa to player.
        santa = GameObject.FindGameObjectWithTag("Player").GetComponent<Santa>();

        // Set the chimney spawner to spawner
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ChimneySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // Delete gift if below threshold...
        if (transform.position.y < -4)
        {
            Destroy(gameObject);
            santa.lives--;
        }
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        if (collided.collider.tag == "ChimneyEntrance")
        {
            santa.score++;

            Chimney chimney = collided.gameObject.GetComponentInParent<Chimney>();

            if (santa.score != 0 && santa.score%20 == 0)
            {
                spawner.chimneySpeed++;
            }
        }
        else
            santa.lives--;
        
        Destroy(gameObject);
    }
}
