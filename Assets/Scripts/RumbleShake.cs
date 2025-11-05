using UnityEngine;

public class RumbleShake : BaseShake
{
    [SerializeField] private float rumbleFrequency = 200f;
    [SerializeField] private float rumbleOffset = 0.5f;
    AnimationCurve rumbleCurve;

    protected override Vector3 CalculateShakeOffset(float elapsedTime)
    {
        rumbleCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, rumbleFrequency);
        float x = (Mathf.PerlinNoise(elapsedTime * rumbleFrequency, 0) - rumbleOffset) * magnitude;
        float y = (Mathf.PerlinNoise(0, elapsedTime * rumbleFrequency) - rumbleOffset) * magnitude;

        return new Vector3(x, y, 0f);
    }
}
