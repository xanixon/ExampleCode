using UnityEngine;

public abstract class BaseFishingHandler : MonoBehaviour
{
    [SerializeField] protected BaseFishplacePresenter place;

    public abstract void HookTheFish();
    public abstract void StartFishing();
    public abstract void SetFishplace(BaseFishplacePresenter newPlace);
    protected abstract void restart();
}
