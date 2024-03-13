using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUpgrade : ScriptableObject
{
    public string UpgradeName;
    [TextAreaAttribute(4,4)]
    public string LoreDescription;
    public Sprite Icon;
    public int Id;
    public int Price;  

    public abstract SavableConfig ApplyUpgrade(BoatFitter fitter);
}
