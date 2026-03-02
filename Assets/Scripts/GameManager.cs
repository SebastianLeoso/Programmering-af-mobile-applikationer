using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    [SerializeField] float spawnRate;

    bool gameStarted = false;

    Vector2 screenPos;

    public TextMeshProUGUI scoreText;

    public GameObject tapToStart;

    [SerializeField] GameObject player;

    void Update()
    {
        if (transform.GetComponent<InputSystem>().IsPressing(out screenPos) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            tapToStart.SetActive(false);

        }
    }
    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, spawnRate);
    }
    public void SpawnEnemy()
    {
        float randomX = Random.Range(0f,1f);

        Vector2 viewPortPos = new Vector2(randomX, 1f);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPortPos);

        int prefabIndex = Random.Range(0, 1);

        Debug.Log(prefabIndex);
        
        Instantiate (enemyPrefab[Random.Range(0, enemyPrefab.Length)], worldPos, Quaternion.identity);

        player.GetComponent<Player>().dodAtt.UpdateScore(1);

        UpdateText(player.GetComponent<Player>().dodAtt.score);
    }

    void UpdateText(int score)
    {
        scoreText.text = score.ToString();
    }
}
