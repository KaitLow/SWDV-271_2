using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;

// test commit comment
public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f; //default 4 meters
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f; //default 4 meters
    [Tooltip("In meters")][SerializeField] const float xRange = 6.01f;  // limit range of ship
    [Tooltip("In meters")] [SerializeField] const float yMin = 3.97f;  // limit range of ship
    [Tooltip("In meters")] [SerializeField] const float yMax = 3.97f;  // limit range of ship

    [SerializeField] float positionPitchFactor = -6.5f;
    [SerializeField] float controlPitchFactor = -6.5f;
    [SerializeField] float positionYawFactor = 6.5f;
    [SerializeField] float controlYawFactor = 6.5f;
    [SerializeField] float controlRollFactor = -24f;
    float xThrow, yThrow;  // need to access this infor from other locations.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        ProcessTranslation();  // takes place before ProcessRotation() to set Throw
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControlThrow = xThrow * controlYawFactor;
        float yaw = yawDueToPosition + yawDueToControlThrow;

        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    // Update is called once per frame
    void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawXPosition, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPosition = transform.localPosition.y + yOffset;
        float clampedYPosition = Mathf.Clamp(rawYPosition, -yMin, yMax);


        transform.localPosition = new Vector3(
            clampedXPosition,
            clampedYPosition,
            transform.localPosition.z);
    }
}
