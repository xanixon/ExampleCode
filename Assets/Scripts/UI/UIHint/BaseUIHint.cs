using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseUIHint : MonoBehaviour
{
    [SerializeField] protected TMP_Text hintText;
    [SerializeField] protected float clearDelay = 2f;
    public void SetHint(string text)
    {
        hintText.text = text;
        StopAllCoroutines();
        StartCoroutine(clearHintText(clearDelay));
    }

    protected IEnumerator clearHintText(float duration)
    {
        float elapsed = 0;
        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        hintText.text = "";
    }
}
