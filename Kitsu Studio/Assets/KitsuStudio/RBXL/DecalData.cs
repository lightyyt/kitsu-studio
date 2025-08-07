using KitsuStudio.Enums;
using UnityEngine;

namespace KitsuStudio.RBXL
{
    public static class DecalPositions
    {
        //FRONT = -Z
        //BACK  = +Z
        //LEFT  = -X
        //RIGHT = +X
        //TOP   = +Y
        //BOTTOM= -Y
        private static float side = 0.5015f;
        public static Vector3 Front = new(0, 0, -side);
        public static Vector3 Back  = new(0, 0, side);
        public static Vector3 Left  = new(-side, 0, 0);
        public static Vector3 Right = new(side, 0, 0);
        public static Vector3 Top   = new(0, side, 0);
        public static Vector3 Bottom = new(0, -side, 0);

        public static Vector3 getFromFace(Face face)
        {
            switch (face)
            {
                case Face.FRONT:
                    return Front;
                case Face.BACK:
                    return Back;
                case Face.LEFT:
                    return Left;
                case Face.RIGHT:
                    return Right;
                case Face.TOP:
                    return Top;
                case Face.BOTTOM:
                    return Bottom;
            }

            return Vector3.zero; //Never happens, but C# Complains
        }
    }
    
    public static class DecalRotations
    {
        public static Vector3 Front = new(0, 0, 0);
        public static Vector3 Back  = new(0, 180,0);
        public static Vector3 Left  = new(0, 90, 0);
        public static Vector3 Right = new(0, -90, 0);
        public static Vector3 Top   = new(90, 0, 0);
        public static Vector3 Bottom = new(-90, 0, 0);
        
        public static Vector3 getFromFace(Face face)
        {
            switch (face)
            {
                case Face.FRONT:
                    return Front;
                case Face.BACK:
                    return Back;
                case Face.LEFT:
                    return Left;
                case Face.RIGHT:
                    return Right;
                case Face.TOP:
                    return Top;
                case Face.BOTTOM:
                    return Bottom;
            }

            return Vector3.zero; //Never happens, but C# Complains
        }
    }
}