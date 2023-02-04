
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Conversation", order = 2)]
public class DialogueSO : ScriptableObject
{
    /// <summary>
    /// Displays the CharNameList for refernce for the Ids
    /// </summary>
    [SerializeField] string[] charNames = new string[6] { "Speaker" , "Ven" , "Keian" , "Dwayne", "Vara", "Tucker" };


    /// <summary>
    /// The storage array for the IDs of the character that talks at that Index point
    /// </summary>
    [SerializeField] int[] sentencesNameID;
    [SerializeField] string[] sentences;
    public int ID;


    public string[] GetSentences()
    {
        return sentences;
    }

    public int[] GetSentencesNameID()
    {
        return sentencesNameID;
    }

}
