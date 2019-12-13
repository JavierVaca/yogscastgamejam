
using UnityEngine;

public class ChimneySpawner : MonoBehaviour
{
    private float timer = 0f;

    private float spawnTime = 0.5f;

    void Start()
    {
        // Set random spawn time at start of game.
        spawnTime = Random.Range(0.15f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        NewChimney();

        timer += Time.deltaTime;
    }

    // Spawn new chimney every
    void NewChimney()
    {
        if (timer > spawnTime)
        {
            Instantiate(
                (GameObject)Resources.Load("Prefabs/Chimney"),
                transform.position,
                Quaternion.identity
            );

            timer = 0f;
            spawnTime = Random.Range(0.15f, 0.8f);
        }
    }
}
