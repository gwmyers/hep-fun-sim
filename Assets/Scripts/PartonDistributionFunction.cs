using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class to manage PDF related probability calculations
/// </summary>
public class PartonDistributionFunction
{
    protected double centerOfMassEnergy = 13.0;
    protected WeightTable partonNumberWeightTable = new WeightTable();
    protected WeightTable flavorWeightTable = new WeightTable();

    // placeholeder probabilities:
    public static Dictionary<string, int> X_a = new Dictionary<string, int>()
    {
        {"g", 50000},
        {"u", 20000},
        {"d", 20000},
        {"s", 900},
        {"c", 100},
        {"b", 15},
        {"t", 1} 
    };


    /// <summary>
    /// Default constructor
    /// </summary>
    public PartonDistributionFunction()
    {
        // initialize number of partons weight table:
        partonNumberWeightTable.addEntry(8, 100);
        partonNumberWeightTable.addEntry(9, 100);
        partonNumberWeightTable.addEntry(10, 100);
        partonNumberWeightTable.addEntry(11, 100);
        partonNumberWeightTable.addEntry(12, 100);


        // initialize flavor weight table:
        foreach (KeyValuePair<string, int> kvp in X_a)
        {
            flavorWeightTable.addEntry(StandardModelDefs.particleID[kvp.Key], kvp.Value);
        }
    }

    /// <summary>
    /// return a list of partons inside a proton at the time of collision
    /// </summary>
    /// <returns> an integer list of parton IDs to instantiate </returns>
    public List<int> generatePartonContent()
    {
        List<int> partonComposition = new List<int>();
        int nPartons = partonNumberWeightTable.getRandomID();

        for (int iParton = 0; iParton < nPartons; iParton++)
        {
            partonComposition.Add(flavorWeightTable.getRandomID());
        }

        return partonComposition;
    }
}
