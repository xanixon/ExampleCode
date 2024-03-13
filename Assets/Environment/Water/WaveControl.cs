using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour //TODO: сделать шейдером, а не этим вот безобразием
{
    [SerializeField] private Material waterMaterial;
    [SerializeField] private Vector2 waveSpeed;
    [SerializeField] private float maxWaveStrength = 1;
    [SerializeField] private float minWaveStrength = 0.2f;
    [SerializeField] private float wavePeriod = 5;

    private Vector2 textureOffset;
    // Start is called before the first frame update
    void Start()
    {
        textureOffset = waterMaterial.GetTextureOffset("_MainTex");

        StartCoroutine(waveStrengthControl());
        StartCoroutine(normalMapOffsetControl());      
    }

    private IEnumerator waveStrengthControl()
    {
        while (true)
        {
            float elapsed = 0;
            float currentStrength = minWaveStrength;
            while (elapsed < wavePeriod)
            {
                elapsed += Time.deltaTime;
                yield return null;

                float currentT = getWaveCurrentStrength(elapsed);
                currentStrength = Mathf.Lerp(minWaveStrength, maxWaveStrength, currentT);
                waterMaterial.SetFloat("_BumpScale", currentStrength);
            }
        }
        
    }

    private IEnumerator normalMapOffsetControl()
    {
        while (true)
        {
            textureOffset += waveSpeed * Time.deltaTime;
            if (textureOffset.x > 10) textureOffset.x -= 10;
            if (textureOffset.y > 10) textureOffset.y -= 10;
            waterMaterial.SetTextureOffset("_MainTex", textureOffset);
            yield return null;
        }
    }

    private float getWaveCurrentStrength(float elapsed)
    {
        return -Mathf.Abs((2 / wavePeriod) * elapsed - 1) + 1;
    }
}
