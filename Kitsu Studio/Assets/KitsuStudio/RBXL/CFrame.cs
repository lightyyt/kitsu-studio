using System.Globalization;
using System.Xml.Linq;
using UnityEngine;

namespace KitsuStudio.RBXL
{
    public class CFrame
    {
        public float X, Y, Z;
        public float R00, R01, R02;
        public float R10, R11, R12;
        public float R20, R21, R22;

        public CFrame(XElement element)
        {
            X = float.Parse(element.Element("X")?.Value ?? "0", CultureInfo.InvariantCulture);
            Y = float.Parse(element.Element("Y")?.Value ?? "0", CultureInfo.InvariantCulture);
            Z = float.Parse(element.Element("Z")?.Value ?? "0", CultureInfo.InvariantCulture);

            R00 = float.Parse(element.Element("R00")?.Value ?? "1", CultureInfo.InvariantCulture);
            R01 = float.Parse(element.Element("R01")?.Value ?? "0", CultureInfo.InvariantCulture);
            R02 = float.Parse(element.Element("R02")?.Value ?? "0", CultureInfo.InvariantCulture);
            R10 = float.Parse(element.Element("R10")?.Value ?? "0", CultureInfo.InvariantCulture);
            R11 = float.Parse(element.Element("R11")?.Value ?? "1", CultureInfo.InvariantCulture);
            R12 = float.Parse(element.Element("R12")?.Value ?? "0", CultureInfo.InvariantCulture);
            R20 = float.Parse(element.Element("R20")?.Value ?? "0", CultureInfo.InvariantCulture);
            R21 = float.Parse(element.Element("R21")?.Value ?? "0", CultureInfo.InvariantCulture);
            R22 = float.Parse(element.Element("R22")?.Value ?? "1", CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            return $"CFrame(X:{X}, Y:{Y}, Z:{Z}, R00:{R00}, R01:{R01}, R02:{R02}, R10:{R10}, R11:{R11}, R12:{R12}, R20:{R20}, R21:{R21}, R22:{R22})";
        }

        private Quaternion ToQuaternion()
        {
            Matrix4x4 m = new Matrix4x4();
            m.m00 = R00; m.m01 = R01; m.m02 = R02; m.m03 = 0f;
            m.m10 = R10; m.m11 = R11; m.m12 = R12; m.m13 = 0f;
            m.m20 = R20; m.m21 = R21; m.m22 = R22; m.m23 = 0f;
            m.m30 = 0f;  m.m31 = 0f;  m.m32 = 0f;  m.m33 = 1f;

            return m.rotation;
        }

        public void SetTransform(Transform t)
        {
            t.position = new Vector3(X, Y, Z);
            t.rotation = ToQuaternion();
        }
    }
}