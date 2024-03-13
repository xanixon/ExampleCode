using UnityEngine;
using Zenject;

[RequireComponent(typeof(BaseFishplaceView))]
public class FishplacePresenter : BaseFishplacePresenter
{
    [Inject]
    public void Construct(BaseFishplaceManager manager)
    {
        Init();
        manager.RegisterFishplace(this);
    }

    public override void Init()
    {
        view = GetComponent<BaseFishplaceView>();
        view.Init(this);
        view.OnViewRemoveFish += removeFish;
        model = new FishplaceModel(view.FishMaxCount);
        model.OnRemoveFish += updateView;
        model.OnFishplaceDeplited += destroyFishingPlace;
    }
    private void removeFish()
    {        
        model.RemoveFish();        
    }

    private void updateView()
    {
        view.UpdateView(FishLeft);
    }

    private void destroyFishingPlace()
    {
        Destroy(gameObject);
    }
    public class Factory : PlaceholderFactory<FishplacePresenter>
    {
    }
}
