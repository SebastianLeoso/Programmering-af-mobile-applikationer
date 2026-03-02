using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;
    Rigidbody2D rb;
    public DodgerAttributes dodAtt;

    [SerializeField] InputSystem inputSys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Start()
    {
        dodAtt = new DodgerAttributes(5,5,0);
    }

    // Update is called once per frame
    void Update()
    {           
        float moveDir = 0f;

        Vector2 screenPos;

        if (inputSys.IsPressing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint
                (new Vector3(screenPos.x, screenPos.y, 0f));

            if (touchPos.x < 0)
            {
                moveDir = -1f;
            }
            else
            {
                moveDir = 1f;
            }
        }


        Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

        if ((viewportPos.x <= 0f && moveDir < 0f) || (viewportPos.x >= 1f && moveDir > 0f))
        {
            moveDir = 0f;
        }

        rb.linearVelocityX = moveDir * moveSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            dodAtt.TakeDamage(1);
            Destroy(collision.gameObject);
            if (dodAtt.Health <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
