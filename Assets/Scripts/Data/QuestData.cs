using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
