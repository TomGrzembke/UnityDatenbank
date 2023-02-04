
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This Class contains all variables of the game which should be saved
/// </summary>
[System.Serializable]
public class GameData
{
    public Vector3 playerPos;
    public Vector3 keianPos;
    public int potAmount;
    public bool keianActive;
    public DwayneData dwayneData = new();
    public bool cityDestroyed;
    public bool exitDoorOpen;

   
    /// <summary>
    /// The collected ItemSos in the playerInventory
    /// </summary>
    public List<ItemSO> itemSos;
    /// <summary>
    /// The stored ItemSos in the altar
    /// </summary>
    public List<ItemSO> altarItemSos;

    /// <summary>
    /// Stores the states if the 7 colliders should be enabled or not
    /// </summary>
    public bool[] colliderShouldBeEnabled;
    /// <summary>
    /// Saves if the combats are done, 0: Tutorial, 1: 
    /// </summary>
    public bool[] combatsDone;
    /// <summary>
    /// Is used for not repeating a dialogue from a combat on load
    /// </summary>
    public bool[] shouldReceiveCombatReward;

    /// <summary>
    /// The current music state
    /// </summary>
    public MusicController.MusicState musicState;

    public QuestSO currentQuestSO;

    /// <summary>
    /// Those are the default values that the game will start with
    /// </summary>
    public GameData()
    {
        this.dwayneData.dwaynePos = new Vector3(72.97f, 16.88f, 0);
        this.keianPos = new Vector3(25.3f, -3.79f, 0);
        this.playerPos = new Vector3(-83.92f, 12.44f, 0f);
        this.potAmount = 0;
        this.keianActive = false;
        this.cityDestroyed = false;
        this.musicState = MusicController.MusicState.oWIntroLoop;
        this.itemSos = new();
        this.altarItemSos = new();
        this.combatsDone = new bool[3];
        this.shouldReceiveCombatReward = new bool[3] {true,true,true};
        this.currentQuestSO = null;
        colliderShouldBeEnabled = new bool[9] { true, true, true, true, true, true, true, false, false };
    }
}
