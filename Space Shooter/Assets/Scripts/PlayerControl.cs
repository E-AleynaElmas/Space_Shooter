using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody physics;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float characterSpeed;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float slope;
    float fireTime = 0;
    public float passingTime;
    public GameObject bullet;
    public Transform bulletTransform;
    AudioSource audio;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal,0,vertical);
        physics.velocity = vec*characterSpeed;
        physics.position = new Vector3
        (
            Mathf.Clamp(physics.position.x,minX,maxX),
            0.0f,
            Mathf.Clamp(physics.position.z,minZ,maxZ)
         );
        physics.rotation = Quaternion.Euler(0, 0, physics.velocity.x*-slope);
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>fireTime)
        {
            fireTime = Time.time + passingTime;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            audio.Play();
        }
    }
}
