
using UnityEngine;

public class ChimneySpawner : MonoBehaviour
{
    private float timer = 0f;

    private float spawnTime = 0.5f;

    private float[] minMaxSpawn = {1f, 3.0f};

    public float chimneySpeed = 2;

    void Start()
    {
        // Set random spawn time at start of game.
        spawnTime = Random.Range(minMaxSpawn[0], minMaxSpawn[1]);
    }

    // Update is called once per frame
    void Update()
    {
        //NewChimney();
        NewHouse();
        timer += Time.deltaTime;
    }

    // Spawn new chimney every
    void NewChimney(Vector2 position)
    {
            Instantiate(
                (GameObject)Resources.Load("Prefabs/Chimney"),
                position,
                Quaternion.identity
            );
        
    }

    void NewHouse()
    {

        if (timer > spawnTime)
        {
            var height = Random.Range(1, 4);
            float positionY = transform.position.y;
            int spriteIndex = 0;
            for (int i = 0; i <= height + 1; i++)
            {
                var position = transform.position;
                position.y = positionY;
                if (i == height + 1)
                {
                    NewChimney(new Vector2(transform.position.x, positionY));
                }
                else
                {
                    var ds = Instantiate(
               (GameObject)Resources.Load("Prefabs/House"),
               position,
               Quaternion.identity
            );
                    Sprite[] sprites = Resources.LoadAll<Sprite>("Art/house-tiles");
                    var sprite = ds.GetComponent<SpriteRenderer>();

                    if (i == 0)
                    {
                        int[] housetype = new int[] { 0, 1, 6 };
                        spriteIndex = housetype[Random.Range(0, 3)];
                        sprite.sprite = sprites[spriteIndex];
                    }
                    else if (spriteIndex == 0)
                    {
                        sprite.sprite = sprites[2];
                    }
                    else if (spriteIndex == 1)
                    {
                        sprite.sprite = sprites[Random.Range(3, 5)];
                    }
                    else if (spriteIndex == 6)
                    {
                        sprite.sprite = sprites[5];
                    }
                    positionY += sprite.sprite.bounds.extents.y * 2;
                }
                               
                timer = 0f;
                spawnTime = Random.Range(minMaxSpawn[0], minMaxSpawn[1]);               
            }
          
        }
    }
}
