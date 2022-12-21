using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("General ship settings")]
    [Tooltip("How fast ship is moving up/down left/right")][SerializeField] float movingSpeed =10f;
    [Tooltip("Move range on X axis")][SerializeField] float xRange = 8f;
    [Tooltip("Move range on Y axis")][SerializeField] float yRange = 6f;

    [Header("General screen positioning")]
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlRollFactor = -10f;
    [Header("General input positioning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] GameObject[] lasers;
    [SerializeField] public GameObject deathObject;
    float horizontalMove, verticalMove;
    bool fireLasers;
    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        Fire();
    }

    void Movement()
    {

        horizontalMove = Input.GetAxis("Horizontal");
        float newHorizontalPos = transform.localPosition.x + (horizontalMove * movingSpeed * Time.deltaTime);
        float clampedXPos = Mathf.Clamp(newHorizontalPos, -xRange, xRange);


        verticalMove = Input.GetAxis("Vertical");
        float newVerticalPos = transform.localPosition.y + (verticalMove * movingSpeed * Time.deltaTime);
        float clampedYPos = Mathf.Clamp(newVerticalPos, -yRange, yRange);

        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            transform.localPosition.z
            );
    }
    void Rotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlMove = verticalMove * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlMove;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float rollDueToControlMove = horizontalMove * controlRollFactor;
        float roll = rollDueToControlMove;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void Fire()
    {
        fireLasers = Input.GetKey(KeyCode.Mouse0);
        if (fireLasers)
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }
    void SetLasersActive(bool val)
    {
        foreach (GameObject item in lasers)
        {
            ParticleSystem.EmissionModule particleEmission = item.GetComponent<ParticleSystem>().emission;
            particleEmission.enabled = val;

        }
    }

}
