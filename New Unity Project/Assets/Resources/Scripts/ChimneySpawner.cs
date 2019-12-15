
using UnityEngine;

public class ChimneySpawner : MonoBehaviour
{
    private float timer = 0f;

    private float spawnTime = 0.5f;

    private float[] minMaxSpawn = {0.5f, 2.0f};

    public float chimneySpeed = 2;

    void Start()
    {
        // Set random spawn time at start of game.
        spawnTime = Random.Range(minMaxSpawn[0], minMaxSpawn[1]);
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
            GameObject newChimney = (GameObject)Resources.Load("Prefabs/Chimney");

            Instantiate(
                newChimney,
                transform.position,
                Quaternion.identity
            );

            Debug.Log(chimneySpeed);

            timer = 0f;
            spawnTime = Random.Range(minMaxSpawn[0], minMaxSpawn[1]);
        }
    }
}
