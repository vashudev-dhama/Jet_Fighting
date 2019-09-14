using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] private float xSpeed = 50f;
    [Tooltip("In m")] [SerializeField] private float xRange = 12f;
    [SerializeField] float speedMultiplier = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime * speedMultiplier;
        float rawXpos = transform.localPosition.x + xOffset;       
        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);

        //below method will change the local position of the player-plane
        //a new vector3(x,y,z) -- only local x pos need to be updated rest will be same
        transform.localPosition = new Vector3(clampedXpos, transform.localPosition.y, transform.localPosition.z);
        //print(transform.localPosition);
    }
}
