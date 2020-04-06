using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    //public bool isActive;
    public State questState;
    public string[] sentences;
    public GameObject[] needs;
    public int[] needsAmount;
    public GameObject[] rewards;
    public int[] rewardsAmount;
    public int experienceReward;

    public enum State { Unavailable, Available, Progress, Complete}
}
