using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class RecordDataExample : MonoBehaviour
{
    public GameData gameData;

    public Player player;
    public InputAction moveAction;

    float recordTimer = 0;

    public float recordEvery = 1f;

    private void Awake()
    {
        gameData = new GameData();
    }

    private void Start()
    {
        player = player.GetComponent<Player>();
    }
    void OnEnable()
    {
        moveAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        recordTimer += Time.deltaTime;

        if (player.rb.position != Vector2.zero && recordTimer > recordEvery) 
        {
            PlayerData data = new PlayerData();

            recordTimer = 0;

            data.time = Time.time;
            data.posX = player.transform.position.x;
            data.health = player.dodAtt.Health;
            player.dodAtt.score++;
            data.score = player.dodAtt.score;
            

            gameData.entries.Add(data);
        }
    }

    
}
