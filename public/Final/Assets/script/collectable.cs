using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    public collectableType type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player Player = collision.GetComponent<player>();

        if (Player)
        {
            Player.inventory.Add(type);
            Destroy(this.gameObject);
        }
    }
}
public enum collectableType
{
        NONE, tomatoSeed

}