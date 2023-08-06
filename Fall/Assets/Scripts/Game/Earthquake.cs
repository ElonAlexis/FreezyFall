using UnityEngine;

public class Earthquake : MonoBehaviour
{
    public float shakeDuration = 1f;
    public float shakeMagnitude = 0.5f;

    private float shakeTimer;
    private Vector3 initialPosition;

    public bool shake; 

    void Start()
    {
        // Store the initial _position of the camera
        initialPosition = transform.localPosition;
    }

    void Update()
    {

        if(shake)
        {
            Shake();
            shake = false;
        }
        if (shakeTimer > 0)
        {
            // Calculate the shake offset based on Perlin noise
            float x = Random.value * 2f - 1f;
            float y = Random.value * 2f - 1f;
            Vector3 shakeOffset = new Vector3(x, y, 0f) * shakeMagnitude;

            // Add the shake offset to the initial _position to get the new _position
            transform.localPosition = initialPosition + shakeOffset;

            // Decrease the shake timer over time
            shakeTimer -= Time.deltaTime;

            // Vibrate the phone
            Handheld.Vibrate();
        }
        else
        {
            // Reset the camera _position to the initial _position
            transform.localPosition = initialPosition;
        }
    }

    public void Shake()
    {
        // Start shaking the camera
        shakeTimer = shakeDuration;
    }
}
