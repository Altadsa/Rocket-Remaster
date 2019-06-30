using UnityEngine;

public static class Accelerometer
{
    static Matrix4x4 baseMatrix = Matrix4x4.identity;

    public static void Calibrate()
    {
        Quaternion rotate = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), Input.acceleration);

        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotate, new Vector3(1.0f, 1.0f, 1.0f));

        baseMatrix = matrix.inverse;
    }

    public static Vector3 Value => baseMatrix.MultiplyVector(Input.acceleration);
}
