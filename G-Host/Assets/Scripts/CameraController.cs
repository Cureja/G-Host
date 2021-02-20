using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerObject;
    public new Camera camera;
    public float cameraRadius = 4.0f;
    public float cameraSpeed = 8.0f;

    public float shakeAmount;
    public float shakeSpeed;
    public float shakeDuration;
    public float decreaseFactor = 1.0f;

    private float pistolShakeAmount = 0.15f;
    private float pistolShakeSpeed = 80f;
    private float pistolShakeDuration = 0.1f;

    private float shotgunShakeAmount = 0.25f;
    private float shotgunShakeSpeed = 90f;
    private float shotgunShakeDuration = 0.1f;
    
    Vector3 shakeNewPos;
    Vector3 cameraNewPos;

    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    void FixedUpdate()
    {

        if (shakeDuration > 0)
        {
            shakeNewPos = transform.position + Random.insideUnitSphere * shakeAmount;
            shakeNewPos = new Vector3(shakeNewPos.x, shakeNewPos.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, shakeNewPos, Time.deltaTime * shakeSpeed);
            shakeDuration -= Time.deltaTime;
        }
        //camera follows mode
        else {
            cameraNewPos = new Vector3(playerObject.transform.position.x,  playerObject.transform.position.y, transform.position.z);
            transform.position = cameraNewPos;
        }
        
    }

    public void pistolShake()
    {
        setShakeProperties(pistolShakeAmount, pistolShakeSpeed, pistolShakeDuration);
    }

    public void shotgunShake()
    {
        setShakeProperties(shotgunShakeAmount, shotgunShakeSpeed, shotgunShakeDuration);
    }

    public void setShakeProperties(float shakeAmount, float shakeSpeed, float shakeDuration)
    {
        this.shakeAmount = shakeAmount;
        this.shakeSpeed = shakeSpeed;
        this.shakeDuration = shakeDuration;
    }
}
