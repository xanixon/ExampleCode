using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseUIHint : MonoBehaviour
{
    [SerializeField] protected TMP_Text hintText;

    public void SetHint(string text)
    {
        hintText.text = text;
    }
}
