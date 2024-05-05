using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public inventario inventory;
    private void Start()
    {
        inventory = new inventario(30);
    }
}
