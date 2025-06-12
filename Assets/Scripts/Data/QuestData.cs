using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class QuestData : DataBase
{
    public string QuestID;
    public string Name;
    public int Type;
    public int NPC;
    public int Goal;
    public string Description;
    public int PriorID;
    public int GoalID;
    public int Exp;
    public int Gold;
    public bool Clear;
    public int Reward;

    public override string Key => QuestID;

    public override string KeyName => Name;

    public QuestData(QuestData other)
    {
        if (other == null)
            return;

        QuestID = other.QuestID;
        Name = other.Name;
        Type = other.Type;
        NPC = other.NPC;
        Goal = other.Goal;
        Description = other.Description;
        PriorID = other.PriorID;
        GoalID = other.GoalID;
        Exp = other.Exp;
        Gold = other.Gold;
        Clear = other.Clear;
        Reward = other.Reward;
    }
}
