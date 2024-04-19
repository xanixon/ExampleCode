using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidSwipeKeyBinding : KeyBinding
{
    public float SwipeMinLength = 150;

    private Vector2 startPoint;

    public AndroidSwipeKeyBinding() { }
    public override float GetFloat()
    {
        float result = 0;
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
                if (swipeDistance > SwipeMinLength)
                {
                    if (direction.x > 0)
                        result = 1;
                    else
                        result = -1;
                }
            }
        }
       
        return result;
    }
}
