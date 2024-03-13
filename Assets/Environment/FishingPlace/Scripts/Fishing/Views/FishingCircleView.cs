using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishingCircleView : FishingBobberView
{
    [SerializeField] private RectTransform hookCircleTr;
    [SerializeField] private Image hookCircleImage;
    [SerializeField] private TMP_Text fishStatsText;
    [SerializeField]
    private Color failColor = Color.red,
                   commonColor = Color.white,
                   successColor = Color.green;

    [SerializeField]
    private float minSize,
                  maxSize,
                  startSize;
    [SerializeField]
    private GameObject fishingPanel,
                       hotkeyHintStart,
                       hotkeyHintHook,
                       fishLeftPanel;    

    [SerializeField] private Animator fishLeftAnim;
    private float successCircleSize;
    private int prevFishCount = 0;    

    public override void Init(BaseFishingPresenter presenter)
    {
        base.Init(presenter);
        successCircleSize = bobberPresenter.SuccessBobberPosition;
        SetFishplace(null);
    }
    public override void UpdateView()
    {
        if(!fishingPanel.activeSelf) { return; }
        float currentSize = bobberPresenter.CurrentBobberPosition;
        colorHandler(currentSize);
        sizeHandler(currentSize);
    }

    public override void UpdateFishUI(int fishLeft, int maxFish)
    {        
        fishStatsText.text = $"{fishLeft}/{maxFish}";
        if(prevFishCount != fishLeft)
        {
            fishLeftAnim.SetTrigger("Notify");
            if (fishLeft > 0)
                HideFishingScreen(true);
            else
                HideFishingScreen(false);
        }
            
        prevFishCount = fishLeft;
    }

    public override void ToggleFishingObject(bool isFishingStarted)
    {
        if (isFishingStarted)
            ShowFishingScreen();
        else        
            HideFishingScreen(presenter.hasFishplace);           
    }
    public override void SetFishplace(BaseFishplaceView fishplace)
    {
        if(fishplace == null)
        {
            HideFishingScreen();
            fishLeftPanel.SetActive(false);
        }
        else
        {
            fishLeftPanel.SetActive(true);
            hotkeyHintStart.SetActive(true);
        }
        OnFishplaceSet?.Invoke(fishplace);
    }

    public override void OnHook()
    {        
        if (presenter.fishingInProgress)
            base.OnHook();               
    }

    public override void OnStartFishing()
    {
        if (!presenter.fishingInProgress)
            base.OnStartFishing();         
    }

    public void ShowFishingScreen()
    {
        hotkeyHintStart.SetActive(false);
        fishingPanel.SetActive(true);
    }

    public void HideFishingScreen(bool showStartFishingHint = false)
    {
        if(showStartFishingHint)
           hotkeyHintStart.SetActive(true);
        else
            hotkeyHintStart.SetActive(false);
        fishingPanel.SetActive(false);
    }
    private void colorHandler(float currentSize)
    {
        if (currentSize < successCircleSize)
        {
            hookCircleImage.color = successColor;
        }
        else if (currentSize < startSize)
        {
            hookCircleImage.color = commonColor;
        }
        else if (currentSize < maxSize)
        {
            hookCircleImage.color = failColor;
        }
    }

    private void sizeHandler(float currentSize)
    {
        float newSize = Mathf.Lerp(minSize, startSize, currentSize);
        newSize = Mathf.Clamp(newSize, minSize, maxSize); 
        hookCircleTr.localScale = new Vector3(newSize, newSize, newSize);
    }
}
