using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quests", order = 4)]
public class QuestSO : ScriptableObject
{
    public string questName = "Main Quest";
    /// <summary>
    /// Will be used to pass the shortDescription of each quest milestone
    /// </summary>
    public string questShortDescripton;
    [TextArea]
    public string questDetailedDescription;
}

