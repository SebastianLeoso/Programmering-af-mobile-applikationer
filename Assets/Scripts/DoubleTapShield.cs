using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using System.Collections;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class DoubleTapShield : MonoBehaviour
{
    [SerializeField] GameObject shield;
    [SerializeField] float maxTapDelay = 0.3f;

    float lastTapTime = 0f;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update()
    {
        if (touch.activeTouches.Count < 1)
            return;

        var touch1 = touch.activeTouches[0];

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            float timeSinceLastTap = Time.time - lastTapTime;

            if (timeSinceLastTap <= maxTapDelay)
            {
                StartCoroutine(TempShield(5f));
                lastTapTime = 0f;
            }
            else
            {
                lastTapTime = Time.time;
            }
        }
    }

    IEnumerator TempShield (float duration)
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(duration);
        shield.SetActive(false);
    }
}
