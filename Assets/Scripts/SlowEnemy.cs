using UnityEngine;

public class SlowEnemy : BaseEnemy
{

    void Awake()
    {
        gravityScale = 0.5f;
    }
    
}
