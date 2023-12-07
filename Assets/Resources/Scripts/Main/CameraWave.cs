using UnityEngine;

public class CameraWave : MonoBehaviour
{
    public float waveSpeed = 1.0f;
    public float waveHeight = 0.1f;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float time = (Time.time - startTime) * waveSpeed;
        float xWave = Mathf.Sin(time) * waveHeight;
        float yWave = Mathf.Cos(time * 0.5f) * waveHeight;

        transform.position = new Vector3(xWave, yWave, transform.position.z);
    }
}