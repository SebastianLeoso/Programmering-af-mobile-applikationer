using UnityEngine;

public class DodgerAttributes
{
    public int Health;
    public int maxHealth;
    public int score;

    public DodgerAttributes(int currentHealth, int maximumHealth, int currentScore)
    {
        Health = currentHealth;
        maxHealth = maximumHealth;
        score = currentScore;
    }

    public void ResetHealth()
    {
        Health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
    }
}
