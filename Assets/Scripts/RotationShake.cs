using UnityEngine;

public class RotationShake : BaseShake
{
    [SerializeField] float rotationAmount = 3.0f;
    [SerializeField] AnimationCurve rotationCurve;
    protected override Vector3 CalculateShakeOffset(float elapsedTime)
    {
        float x = (Mathf.PerlinNoise(elapsedTime * frequency, 0) * magnitude);
        float y = (Mathf.PerlinNoise(0, elapsedTime * frequency) * magnitude);
        rotationAmount = rotationCurve.Evaluate(elapsedTime / duration);
        x = Random.Range(-x, x);
        y = Random.Range(-y, y);
        x *= rotationAmount;
        y *= rotationAmount;
        cameraRotation.eulerAngles = new Vector3(x, y, 0);
        transform.rotation = cameraRotation;

        return new Vector3(x * rotationAmount, y * rotationAmount, 0f);
    }
}
