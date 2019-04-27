using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float Thrustspeed = 5f; // int or bool?
    [SerializeField] float Rotationspeed = 5f;
    // Do I need a seperate rotate speed?
    [SerializeField] GameObject[] guns;

    float rotation = 0f; // It may need a more specific name.

    [SerializeField] float angle = 45f;

    void Awake()
    {
        SetGunsActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementControls();
        ProcessFiring();
    }

    private void MovementControls()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * Thrustspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * Thrustspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.up * Thrustspeed * Time.deltaTime);
            //rb2D.velocity = -transform.up * Thrustspeed; // This one causes it to fall.
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.up * Thrustspeed * Time.deltaTime);
            //rb2D.velocity = transform.up * Thrustspeed;
            //transform.Translate(Vector2.up * Thrustspeed * Time.deltaTime);
        }
        //else if (Input.Getkey(keycode.q))
        //{
        //    rotation -= rotationspeed * time.deltatime;

        //if (input.getkey(keycode.e))

        //    rotation += rotationspeed * time.deltatime;

        //    rotation = mathf.clamp(rotation, -90f, 90f);
        //    var clampedrotation = transform.rotation; // this a local quaternion rotation that the transform.rotation is equalling.
        //    clampedrotation.z = rotation; // do i use y, x or z?
        //    transform.rotation = clampedrotation; // ?
        //}

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Find("Paint Cannon Body").Rotate(new Vector3(0, 0, 1) * Rotationspeed * Time.deltaTime, Space.Self);
            //transform.Rotate(Vector3.forward, -Rotationspeed * Time.deltaTime); // Is forward using local or world rotation?
            //rotation -= Rotationspeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Find("Paint Cannon Body").Rotate(new Vector3(0, 0, -1) * Rotationspeed * Time.deltaTime, Space.Self);
            //rotation += Rotationspeed * Time.deltaTime;
        }

        //float minRotation = -45;
        //float maxRotation = 45;
        //Vector3 currentRotation = transform.Find("Paint Cannon Body").localRotation.eulerAngles;
        //currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
        //transform.Find("Paint Cannon Body").localRotation = Quaternion.Euler(currentRotation);
        //print(currentRotation);

        //angle += Input.GetAxis("Vertical") * Time.deltaTime * 10; // There is no name for the z axis so just use vertical and set it with vector3.forward.
        //angle = transform.Rotate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * 10); // Rotate up and down is the z axis in rotation.
        //angle = Mathf.Clamp(angle, 10, 80);
        //transform.Find("Paint Cannon Body").localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void ProcessFiring()
    {
        //if (CrossPlatformInputManager.GetButton("Fire1")) // Should be the mouse right click. Does fuck all.
        if (Input.GetKey(KeyCode.Mouse0)) // OLD CODE: (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed left button.");
            SetGunsActive(true);
            //StartFiringSFX();
            //print("Set guns active true");
        }
        else
        {
            SetGunsActive(false);
            //StopFiringSFX();
            //print("Set guns active false");
        }
    }

    void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            //print("Get particle system");
            emissionModule.enabled = isActive;
            //print("emissionModule isActive");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
