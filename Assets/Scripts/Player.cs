using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] private float Speed = 50f;
    [Tooltip("In m")] [SerializeField] private float xRange = 10f;
    [Tooltip("In m")] [SerializeField] private float yRange = 6f;
    [SerializeField] float speedMultiplier = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime * speedMultiplier;
        float yOffset = yThrow * Speed * Time.deltaTime * speedMultiplier;

        float rawXpos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;

        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);
        float clampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange);

        //below method will change the local position of the player-plane
        //a new vector3(x,y,z) -- only local x & y pos need to be updated rest will be same
        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
        //print(transform.localPosition);
    }
}
