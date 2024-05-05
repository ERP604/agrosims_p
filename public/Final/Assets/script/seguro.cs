using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguro : MonoBehaviour
{
    public void si() {
        mainManager.Instance.seguro = true;
        print("Seguro: " + mainManager.Instance.seguro);
    }

    public void no() {
        mainManager.Instance.seguro = false;
        print("Seguro: " + mainManager.Instance.seguro);
    }
}
