using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// a struct to define ID,weight pairs
/// </summary>
public struct WeightTableEntry
{
    public int uniqueID;
    public int weight;
}

/// <summary>
/// A class to describe a table of integer IDs, weighted
/// by integer amounts - for weighted random applications
/// </summary>
public class WeightTable
{
    private List<WeightTableEntry> weightTable = new List<WeightTableEntry>();
    private int weightSum = 0;

    /// <summary>
    /// Default constructor
    /// </summary>
    public WeightTable()
    {
    }

    /// <summary>
    /// Add an ID to the table with a given weight
    /// </summary>
    /// <param name="ID"> an integer ID, unique in this table </param>
    /// <param name="newWeight"> the weight assigne to ID </param>
    public void addEntry(int ID, int newWeight)
    {
        weightSum += newWeight;
        weightTable.Add(new WeightTableEntry { uniqueID = ID, weight = newWeight });
    }

    /// <summary>
    /// Set the weight for a given ID
    /// </summary>
    /// <param name="ID">an integer ID, unique in this table </param>
    /// <param name="newWeight"> the weight assigne to ID </param>
    public void setWeightForUniqueID(int ID, int newWeight)
    {
        for (int ii = 0; ii < weightTable.Count; ii++)
        {
            WeightTableEntry entry = weightTable[ii];

            if (entry.uniqueID == ID)
            {
                weightSum += newWeight - entry.weight;
                weightTable[ii] = new WeightTableEntry { uniqueID = ID, weight = newWeight };
                break;
            }
        }
    }

    /// <summary>
    /// Remove an entry from the weight table
    /// </summary>
    /// <param name="ID">an integer ID, unique in this table</param>
    public void removeAt(int ID)
    {
        for (int ii = 0; ii < weightTable.Count; ii++)
        {
            WeightTableEntry entry = weightTable[ii];

            if (entry.uniqueID == ID)
            {
                weightSum -= entry.weight;
                weightTable.RemoveAt(ii);
                break;
            }
        }
    }

    /// <summary>
    /// Return a weighted random ID
    /// </summary>
    /// <returns>a weighted random ID</returns>
    public int getRandomID()
    {
        int randID = Random.Range(0, weightTable.Count);
        int cumulativeSum = 0;
        int val = Random.Range(0, weightSum);

        while (cumulativeSum < val)
        {
            randID = Random.Range(0, weightTable.Count);
            cumulativeSum += weightTable[randID].weight;
        }

        return weightTable[randID].uniqueID;
    }
}
