using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat // followed this tutorial: https://www.youtube.com/watch?v=e8GmfoaOB4Y&ab_channel=Brackeys
{
    [SerializeField]
    private int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int netValue = baseValue;
        modifiers.ForEach(x => netValue += x);
        return netValue;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}
