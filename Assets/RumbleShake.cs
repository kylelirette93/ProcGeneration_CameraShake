using UnityEngine;

public class RumbleShake : BaseShake
{
    [SerializeField] private float rumbleFrequency = 200f;

    protected override Vector3 CalculateShakeOffset(float elapsedTime)
    {
        float x = (Mathf.PerlinNoise(elapsedTime * rumbleFrequency, 0) - 0.5f) * magnitude;
        float y = (Mathf.PerlinNoise(0, elapsedTime * rumbleFrequency) - 0.5f) * magnitude;

        return new Vector3(x, y, 0f);
    }
}
