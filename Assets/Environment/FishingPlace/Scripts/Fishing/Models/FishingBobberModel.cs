using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBobberModel : BaseFishingModel
{
    public float CurrentBobberPosition
    {
        get { return currentBobberPosition; }
        set
        {
            currentBobberPosition = Mathf.Clamp(value, 0, 1);
        }
    }

    /// <summary>
    /// Максимальное значение позиции поплавка для успешной подсечки рыбы
    /// </summary>
    public float SuccessBobberPosition
    {
        get { return successBobberPosition; }

        protected set
        {
            successBobberPosition = Mathf.Clamp(value, 0, 1);
        }
    }
    
    [SerializeField] protected float successBobberPosition = 0.3f;
    private float currentBobberPosition;

}
