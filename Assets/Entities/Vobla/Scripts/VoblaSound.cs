using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoblaSound : MonoBehaviour
{
    [SerializeField]
    private float _minPitch = 0.9f,
                                   _maxPitch = 1.1f;
    [SerializeField] private List<AudioClip> _hitSounds = new List<AudioClip>();
    [SerializeField] private List<AudioSource> _sources = new List<AudioSource>();
    [SerializeField] private GameObject _sourcePrefab;
    [SerializeField] private int _maxSourcesCount = 10;

    public void PlayHitSound()
    {
        AudioSource sourceToPlay = findAuidoSource();
        if(sourceToPlay == null)
        {
            if(_sources.Count > _maxSourcesCount) { Debug.LogWarning("Слишком много источников звука для воблы!"); return; }
            GameObject newSourceObject = Instantiate(_sourcePrefab, transform);
            AudioSource newSource = newSourceObject.GetComponent<AudioSource>();
            _sources.Add(newSource);
            sourceToPlay = newSource;
        }
        sourceToPlay.clip = _hitSounds[Random.Range(0, _hitSounds.Count)];
        sourceToPlay.pitch = Random.Range(_minPitch, _maxPitch);
        sourceToPlay.Play();
    }

    private AudioSource findAuidoSource()
    {
        foreach(AudioSource source in _sources)
        {
            if (!source.isPlaying) return source;
        }
        return null;
    }
}
