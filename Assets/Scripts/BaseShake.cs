using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public abstract class BaseShake : MonoBehaviour
{
    [SerializeField] protected float duration = 2.0f;
    [SerializeField] protected float magnitude = 1.0f;
    [SerializeField] protected float frequency = 0.2f;

    protected Transform cameraTransform;
    protected Quaternion cameraRotation;
    protected Vector3 originalPosition;
    protected Quaternion originalRotation;
    protected float elapsedTime = 0f;

    protected virtual void Awake()
    {
        cameraTransform = GetComponent<Camera>().transform;
        cameraRotation = Quaternion.identity;
        originalRotation = cameraRotation;
        originalPosition = cameraTransform.localPosition;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    protected IEnumerator ShakeCoroutine()
    {
        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            Vector3 shakeOffset = CalculateShakeOffset(elapsedTime);

            //cameraTransform.localPosition = originalPosition + shakeOffset;
            cameraRotation = Quaternion.Euler(shakeOffset);

            yield return null;
        }
        //cameraTransform.localPosition = originalPosition;
        cameraRotation = Quaternion.identity;
    }

    protected virtual Vector3 CalculateShakeOffset(float elapsedTime)
    {
        float x = (Mathf.PerlinNoise(elapsedTime * frequency, 0) * magnitude);
        float y = (Mathf.PerlinNoise(0, elapsedTime * frequency) * magnitude);

        return new Vector3(x, y, 0f);
    }
}
