using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hombre : MonoBehaviour
{
    public void Hombre1() {
        mainManager.Instance.hombre = 1;
        print("Hombre 1");
    }

    public void Hombre2() {
        mainManager.Instance.hombre = 2;
        print("Hombre 2");
    }

    public void Hombre3() {
        mainManager.Instance.hombre = 3;
        print("Hombre 3");
    }
}
