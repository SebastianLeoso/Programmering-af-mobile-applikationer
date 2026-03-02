using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{

    public float gravityScale = 1f;
    
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = gravityScale;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.y < -1f)
        {
            Destroy(gameObject);
        }
    }
}

public class Enemy7 : MonoBehaviour
{

    
}
