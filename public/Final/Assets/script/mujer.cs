using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mujer : MonoBehaviour
{
    public void Mujer1() {
        mainManager.Instance.mujer = 1;
        print("Mujer 1");
    }

    public void Mujer2() {
        mainManager.Instance.mujer = 2;
        print("Mujer 2");
    }

    public void Mujer3() {
        mainManager.Instance.mujer = 3;
        print("Mujer 3");
    }
}
