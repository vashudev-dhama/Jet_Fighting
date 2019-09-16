using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] private float Speed = 50f;
    [Tooltip("In m")] [SerializeField] private float xRange = 15f;
    [Tooltip("In m")] [SerializeField] private float yRange = 8f;
    [SerializeField] float speedMultiplier = 1f;
    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] GameObject[] guns;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            //Process the player's trasformations
            ProcessTranslation();

            //Process the player's rotation
            ProcessRotation();

            //Process the player's firing
            ProcessFiring();
        }
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire3"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach(GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    void OnPlayerDeath() //called by string reference in collisionHandler.cs script
    {
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);//(x,y,z) ~ (pitch, yaw, roll)
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime * speedMultiplier;
        float yOffset = yThrow * Speed * Time.deltaTime * speedMultiplier;

        float rawXpos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;

        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);
        float clampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange);

        //below method will change the local position of the player-plane
        //a new vector3(x,y,z) -- only local x & y pos need to be updated rest will be same
        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
