using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RotateDirection
{
    Clockwise, Counterclockwise
}
public enum WeaponLocation
{

    Up = 0,
    Right,
    Down,
    Left,
    Count
}
// public enum WeaponRangeDir
// {
//     LeftUp = 0, RightUp = 1, LeftDown = 2, RightDown = 3, Count
// }

public static class Def
{
    // static public readonly Dictionary<WeaponLocation, Dictionary<RotateDirection, WeaponRangeDir>> GetAttackRange =
    // new Dictionary<WeaponLocation, Dictionary<RotateDirection, WeaponRangeDir>>
    // {
    //     { WeaponLocation.Left, new Dictionary<RotateDirection,WeaponRangeDir>
    //         {
    //             { RotateDirection.Clockwise, WeaponRangeDir.LeftUp },
    //             { RotateDirection.Counterclockwise, WeaponRangeDir.LeftDown }
    //         }
    //     },
    //     { WeaponLocation.Up, new Dictionary<RotateDirection,WeaponRangeDir>
    //         {
    //             { RotateDirection.Clockwise, WeaponRangeDir.RightUp },
    //             { RotateDirection.Counterclockwise, WeaponRangeDir.LeftUp }
    //         }
    //     },
    //     { WeaponLocation.Right, new Dictionary<RotateDirection,WeaponRangeDir>
    //         {
    //             { RotateDirection.Clockwise, WeaponRangeDir.RightDown },
    //             { RotateDirection.Counterclockwise, WeaponRangeDir.RightUp }
    //         }
    //     },
    //     { WeaponLocation.Down, new Dictionary<RotateDirection,WeaponRangeDir>
    //         {
    //             { RotateDirection.Clockwise, WeaponRangeDir.LeftDown },
    //             { RotateDirection.Counterclockwise, WeaponRangeDir.RightDown }
    //         }
    //     },
    // };

    static public readonly float WeaponPlayerDistance = 1f;
    static public readonly Vector2Int TileSize = new Vector2Int(5, 5);
    static public readonly int TileSizeNum = TileSize.x * TileSize.y;
    static public readonly Vector2[] WeaponLocationVec2 = new Vector2[4]{
        Vector2.up, Vector2.right, Vector2.down,Vector2.left
    };

    static public readonly float[] WeaponLocationDegree = new float[4]{
        90, 0, 270,180,
    };

    static public readonly float[] WeaponLocationRadian = new float[4]{
       Mathf.PI / 2, 0, Mathf.PI * 3 / 2, Mathf.PI
    };

    static public Vector3 GetDirection(float angle, float length) { return Quaternion.AngleAxis(angle, Vector3.forward) * new Vector3(length, 0, 0); }
}
