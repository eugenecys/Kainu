using UnityEngine;
using System.Collections;

public static class Utility {
    
    public static float Gaussian(float x, float mu, float sigma)
    {
        return Mathf.Exp(Mathf.Pow(-(x - mu), 2) / (2 * Mathf.Pow(sigma, 2))) / Mathf.Sqrt(2 * Mathf.PI * Mathf.Pow(sigma, 2));

    }
}
