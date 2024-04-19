using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;

    // Update is called once per frame
    void Update()
    {
        textField.text = (1f / Time.deltaTime).ToString("F0");
    }
}
