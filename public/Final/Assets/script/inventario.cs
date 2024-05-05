using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class inventario 
{
    [System.Serializable]
    public class Slot
    {
        public int count;

        public collectableType type;
        public int maxAllowed;

        public Slot()
        {
            count = 0;
            type = collectableType.NONE;
            maxAllowed = 54;
        }

        public bool CanAddItem()
        {
            if(count < maxAllowed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddItem(collectableType type)
        {
            this.type = type;
            count++;
        }
    }
    public List<Slot> slots = new List<Slot>();

    public inventario(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }
    public void Add(collectableType typeToAdd)
    {
        foreach (Slot slot in slots)
        {
            if (slot.type == typeToAdd && slot.CanAddItem())
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }
        foreach (Slot slot in slots)
        {
            if (slot.type == collectableType.NONE)
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }
    }
}