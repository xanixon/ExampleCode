using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidScreenTapKeyBinding : KeyBinding
{
    public float SwipeMinLength = 150;

    private Vector2 startPoint;
    public override bool CheckHit()
    {
        bool result = false;
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPoint = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 direction = touch.position - startPoint;
                float swipeDistance = Vector3.Magnitude(direction);
                if (swipeDistance < SwipeMinLength)
                {
                    result = true;
                }
            }
        }
        return result;
    }
}
