using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackRange
{
    public bool[] ArrayValue = new bool[Def.TileSizeNum];

    public bool[] GetRange(WeaponLocation wl)
    {
        bool[] tempArray = new bool[Def.TileSizeNum];

        switch (wl)
        {
            case WeaponLocation.Up:
                tempArray = ArrayValue;
                break;
            case WeaponLocation.Right:
                for (int y = 0; y < Def.TileSize.y; y++)
                {
                    for (int x = 0; x < Def.TileSize.x; x++)
                    {
                        tempArray[(Def.TileSize.x - x - 1) * Def.TileSize.x + y] = ArrayValue[y * Def.TileSize.x + x];
                    }
                }
                break;
            case WeaponLocation.Down:
                for (int y = 0; y < Def.TileSize.y; y++)
                {
                    for (int x = 0; x < Def.TileSize.x; x++)
                    {
                        tempArray[(Def.TileSize.y - y - 1) * Def.TileSize.x + (Def.TileSize.x - x - 1)] = ArrayValue[y * Def.TileSize.x + x];
                    }
                }
                break;
            case WeaponLocation.Left:
                for (int y = 0; y < Def.TileSize.y; y++)
                {
                    for (int x = 0; x < Def.TileSize.x; x++)
                    {
                        tempArray[x * Def.TileSize.x + (Def.TileSize.y - y - 1)] = ArrayValue[y * Def.TileSize.x + x];
                    }
                }
                break;
        }
        return tempArray;
    }

    public bool this[int index]
    {
        get
        {
            return ArrayValue[index];
        }
        set
        {
            //Debug.Log("Attack Range Change detacted");
            ArrayValue[index] = value;
        }
    }


}
