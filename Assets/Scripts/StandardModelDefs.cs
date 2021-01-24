using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A static class to hold any Standard Model definitions
/// </summary>
public static class StandardModelDefs
{
    // a numerical ID for each particle
    public static Dictionary<string, int> particleID = new Dictionary<string, int>()
    {
        {"e", 0},
        {"mu", 1},
        {"tau", 2},
        {"nu_e", 3},
        {"nu_m", 4},
        {"nu_t", 5},
        {"u", 6},
        {"d", 7},
        {"s", 8},
        {"c", 9},
        {"b", 10},
        {"t", 11},
        {"g", 12},
        {"h", 13},
        {"y", 14},
        {"z", 15},
        {"w", 16}
    };

    // 'classical' EM charges
    public static Dictionary<string, double> charge_EM = new Dictionary<string, double>()
    {
        {"e", -1.0},
        {"mu", -1.0},
        {"tau", -1.0},
        {"nu_e", 0.0},
        {"nu_m", 0.0},
        {"nu_t", 0.0},
        {"u",  2 / 3},
        {"d", -1 / 3},
        {"s", -1 / 3},
        {"c",  2 / 3},
        {"b", -1 / 3},
        {"t",  2 / 3},
        {"g", 0.0 },
        {"h", 0.0 },
        {"y", 0.0 },
        {"z", 0.0 },
        {"w", -1.0}
    };

    // masses (MeV)
    public static Dictionary<string, double> mass = new Dictionary<string, double>()
    {
        {"e", 0.511},
        {"mu", 105.7},
        {"tau", 1780.0},
        {"nu_e", 0.0},
        {"nu_m", 0.0},
        {"nu_t", 0.0},
        {"u", 1.9},
        {"d", 4.4},
        {"s", 87.0},
        {"c", 1320.0},
        {"b", 4240.0},
        {"t", 173500.0},
        {"g", 0.0 },
        {"h", 124970.0},
        {"y", 0.0 },
        {"z", 91190.0 },
        {"w", 80300.0}
    };
}
