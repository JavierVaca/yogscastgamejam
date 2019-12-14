
using UnityEngine;

public class Gift : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Delete gift if below threshold...
        if (transform.position.y < -4)
            Destroy(gameObject);
    }
}
