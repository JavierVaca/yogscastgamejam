
using UnityEngine;

public class ChimneySpawner : MonoBehaviour
{
    public GameUI gameUI;

    private float timer = 0f;

    private float spawnTime = 0.5f;

    private float[] minMaxSpawn = {1f, 3f};

    public float chimneySpeed = 2;

    void Start()
    {
        // Set random spawn time at start of game.
        spawnTime = Random.Range(minMaxSpawn[0], minMaxSpawn[1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameUI.isGameOver)
        {
            NewChimney();
            timer += Time.deltaTime;
        }

        if (gameUI.isGameOver)
        {
            chimneySpeed = 0;
        }
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
