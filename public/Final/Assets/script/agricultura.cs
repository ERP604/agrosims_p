using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agricultura : MonoBehaviour
{
    public void tradicional() {
        mainManager.Instance.agricultura = false;
        mainManager.Instance.agriculturaCosecha = false;
        print("Agricultura tradicional");
        print("Cosecha tradicional");
    }

    public void regenerativa() {
        mainManager.Instance.agricultura = true;
        mainManager.Instance.agriculturaCosecha = true;
        print("Agricultura regenerativa");
        print("Cosecha regenerativa");
    }
}
