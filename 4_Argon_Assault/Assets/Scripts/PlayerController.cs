using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;

// test commit comment
public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f; //default 4 meters
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f; //default 4 meters
    [Tooltip("In meters")][SerializeField] const float xRange = 6.01f;  // limit range of ship
    [Tooltip("In meters")] [SerializeField] const float yMin = 3.97f;  // limit range of ship
    [Tooltip("In meters")] [SerializeField] const float yMax = 3.97f;  // limit range of ship

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -6.5f;
    [SerializeField] float controlPitchFactor = -6.5f;
    [Header("Control-throw Based")]
    [SerializeField] float positionYawFactor = 6.5f;
    [SerializeField] float controlYawFactor = 6.5f;
    [SerializeField] float controlRollFactor = -24f;
    float xThrow, yThrow;  // need to access this infor from other locations.
    bool isControlEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();  // takes place before ProcessRotation() to set Throw
            ProcessRotation();
        }
    }
    void OnPlayerDeath()  //called by string reference
    {
        isControlEnabled = false;
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
