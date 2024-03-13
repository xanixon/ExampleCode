using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BaseFishingView))]
public class FishingBobberPresenter : BaseFishingPresenter
{
    public bool flag;
    public float SuccessBobberPosition { get { return bobberModel.SuccessBobberPosition; } }
    public float CurrentBobberPosition { get { return bobberModel.CurrentBobberPosition; } }
    protected override BaseFishingModel model
    {
        get => bobberModel;
        set
        {
            bobberModel = value is FishingBobberModel ?
                (FishingBobberModel)value :
                null;
        }
    }
    protected FishingBobberModel bobberModel;
    [SerializeField] private float sinkingSpeed = 0.3f;
    /// <summary>
    /// Суммарное время нахождения поплавка в зоне успешной подсечки. По истечении этого времени цикл запустится заново
    /// </summary>
    [SerializeField] private float maxSuccessTime = 1f;

    [SerializeField] private float distortionMaxInterval = 2f;
    [SerializeField] private float distortionMaxDuration = 1f;
    [SerializeField] private float maxDistortionValue = 4f;
    [SerializeField] private float lockDuration = 0.1f;
    private float nextDistortionTime = 0;
    private float distortion = 0;
    private float successTimeLeft = 0;
    private float lastLockTime = 0;

    void Start()
    {
        model = new FishingBobberModel();
        bobberModel = (FishingBobberModel)model;
        view = GetComponent<BaseFishingView>();
        view.Init(this);
        view.OnFishplaceSet += setFishplace;      
        setFishplace(null);
    }
    // Update is called once per frame
    void Update()
    {
        flag = bobberModel.fishingInProgress;
        if (!fishingInProgress) return;
        sizeHandler(bobberModel.CurrentBobberPosition);
        successTimer(bobberModel.CurrentBobberPosition);
        view.UpdateView();        
    }


    protected void fishplaceDeplitedHandler()
    {
        view.SetFishplace(null);
    }

    protected override void startFishing()
    {
        if (Time.time < lastLockTime + lockDuration) 
            return;
        lastLockTime = Time.time;
        if (model.fishplaceView == null)
        {
            Debug.LogError($"Fishplace не был назначен, но рыбалка все равно попыталась стартовать");
            return;
        }
        model.fishingInProgress = true;
        view.HookEventHandler += hookTheFish;
        restart();
    }

    protected override void stopFishing()
    {
        view.HookEventHandler -= hookTheFish;
        model.fishingInProgress = false;
    }

    protected override void setFishplace(BaseFishplaceView newFishplace)
    {
        restart();
        unsubscrubePresenter();
        model.SetFishplace(newFishplace);

        if (newFishplace != null)
        {
            subscribePresenter();
            view.UpdateFishUI(model.FishLeft, model.FishMaxCount);
        }
    }

    protected void subscribePresenter()
    {
        model.OnRemoveFish += updateViewText;
        model.OnFishplaceDeplited += fishplaceDeplitedHandler;
        model.OnFishingStartEnd += toggleViewElements;
        view.StartFishingEventHandler += startFishing;
    }

    protected void unsubscrubePresenter()
    {
        if (model.fishplaceView != null)
        {
            model.OnRemoveFish -= updateViewText;
            model.OnFishplaceDeplited -= fishplaceDeplitedHandler;
            model.OnFishingStartEnd -= toggleViewElements;
            updateViewText();
        }

        view.StartFishingEventHandler -= startFishing;
    }

    protected override void hookTheFish()
    {
        if(Time.time < lastLockTime + lockDuration)
            return;
        lastLockTime = Time.time;
        if (CurrentBobberPosition < SuccessBobberPosition)
            model.RemoveFish(); 
        stopFishing();
    }

    protected override void restart()
    {
        bobberModel.CurrentBobberPosition = 1;
        distortion = 0;
        successTimeLeft = maxSuccessTime;
    }

    private void updateViewText()
    {
        view.UpdateFishUI(model.FishLeft, model.FishMaxCount);
    }

    private void toggleViewElements(bool isFishingInProgress)
    {
        view.ToggleFishingObject(isFishingInProgress);
    }

    private void sizeHandler(float currentSize)
    {
        float constantDelta = sinkingSpeed;
        distortionHandler(constantDelta);

        float delta = constantDelta + distortion;
        currentSize -= delta * Time.deltaTime;

        currentSize = Mathf.Clamp(currentSize, 0f, 1f);
        bobberModel.CurrentBobberPosition = currentSize;
    }

    private void distortionHandler(float constantDelta)
    {
        if (Time.time > nextDistortionTime)
        {
            float interval = Random.Range(0, distortionMaxInterval);
            nextDistortionTime = Time.time + interval;

            float duration = Random.Range(0, distortionMaxDuration);
            float newDistortion = Random.Range(-constantDelta * maxDistortionValue, -constantDelta * maxDistortionValue);

            StartCoroutine(addDistortion(duration, newDistortion));
        }
    }

    private IEnumerator addDistortion(float duration, float newDistortion)
    {
        float elapsed = 0;
        float distortionFadeSpeed = newDistortion / duration;
        distortion += newDistortion;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            distortion -= distortionFadeSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private void successTimer(float currentSize)
    {
        if (currentSize < SuccessBobberPosition)
        {
            successTimeLeft -= Time.deltaTime;
            if (successTimeLeft < 0)
            {
                restart();
                stopFishing();
            }
        }
    }

    private void setLockTime()
    {
        lastLockTime = Time.time;
    }
}