using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorHandler : MonoBehaviour
{
    [SerializeField] private int _tutorialLevelsCount = 3;
    [SerializeField] private Transform _buttonsParent;
    private List<Button> _levelButtons = new List<Button>();
    // Start is called before the first frame update
    void Awake()
    {
        int childCount = _buttonsParent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform buttonTr = _buttonsParent.GetChild(i);
            Button button = buttonTr.GetComponent<Button>();
            button.interactable = false;
            _levelButtons.Add(button);
        }
    }

    public void Init(int levelProgress)
    {
        for (int i = 0; i < _tutorialLevelsCount; i++)
        {
            _levelButtons[i].interactable = true;
        }

        int startIndex = _tutorialLevelsCount; 
        int endIndex = levelProgress + _tutorialLevelsCount;
        endIndex = Mathf.Clamp(endIndex, 0, _levelButtons.Count);
        if (endIndex == _tutorialLevelsCount) endIndex += 1; //+1 чтобы первый уровень был всегда открыт
        for (int i = startIndex; i < endIndex; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }
}
