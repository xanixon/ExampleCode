using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(QuestHolder))]
public class QuestHolderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        QuestHolder holder = (QuestHolder)target;
        IEnumerable<Type> subclasses = typeof(BaseQuest).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(BaseQuest)));
        foreach(Type subclass in subclasses)
        {
            if (GUILayout.Button($"Add {subclass.Name} quest"))
            {
                holder.quests.Add((BaseQuest)Activator.CreateInstance(subclass));
            }
        }
        
    }
}
