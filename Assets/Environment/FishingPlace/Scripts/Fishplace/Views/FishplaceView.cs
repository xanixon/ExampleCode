using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FishplaceView : BaseFishplaceView
{
    public override int FishMaxCount { get { return _fishes.Length;  } }
    [SerializeField] private Animator[] _fishes;

    private BaseFishingView _fishingView;

    [Inject]
    public void Construct(BaseFishingView handler)
    {
        _fishingView = handler;
    }
    private void Start()
    {
        StartCoroutine(AnimationRandomaizator.DesyncronizeFishAnimations(_fishes));
    }

    private void OnTriggerEnter(Collider other)
    {
        _fishingView.SetFishplace(this);
    }

    private void OnTriggerExit(Collider other)
    {
        _fishingView.SetFishplace(null);
    }

    public override void UpdateView(int newCount)
    {
        for (int i = 0; i < _fishes.Length; i++)
        {
            if (i > newCount - 1)
                _fishes[i].gameObject.SetActive(false);
            else
                _fishes[i].gameObject.SetActive(true);
        }            
    }

    public override void RemoveFish()
    {
        OnViewRemoveFish?.Invoke();
    } 
}
