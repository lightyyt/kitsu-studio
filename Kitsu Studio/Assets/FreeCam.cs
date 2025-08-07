using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//https://gist.githubusercontent.com/ashleydavis/f025c03a9221bc840a2b/raw/137fc47cdb32b80c4d3c0203f33df8d8c67a31c6/Unity%2520FreeCam
/// <summary>
/// A simple free camera to be added to a Unity game object.
/// 
/// Keys:
///	wasd / arrows	- movement
///	q/e 			- up/down (local space)
///	r/f 			- up/down (world space)
///	pageup/pagedown	- up/down (world space)
///	hold shift		- enable fast movement mode
///	right mouse  	- enable free look
///	mouse			- free look / rotation
///     
/// </summary>
public class FreeCam : MonoBehaviour
{
    /// <summary>
    /// Normal speed of camera movement.
    /// </summary>
    public float movementSpeed = 10f;

    /// <summary>
    /// Speed of camera movement when shift is held down,
    /// </summary>
    public float fastMovementSpeed = 100f;

    /// <summary>
    /// Sensitivity for free look.
    /// </summary>
    public float freeLookSensitivity = 3f;

    /// <summary>
    /// Amount to zoom the camera when using the mouse wheel.
    /// </summary>
    public float zoomSensitivity = 10f;

    /// <summary>
    /// Amount to zoom the camera when using the mouse wheel (fast mode).
    /// </summary>
    public float fastZoomSensitivity = 50f;

    /// <summary>
    /// Set to true when free looking (on right mouse button).
    /// </summary>
    private bool looking = false;

    [SerializeField] private InputManager input;

    void Update()
    {
        //var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        var movementSpeed = input.GoFast ? this.fastMovementSpeed : this.movementSpeed;
        var moveInput = input.MoveInput.normalized;
        if (moveInput.x < -0.1)
        {
            transform.position = transform.position + (-transform.right * (movementSpeed * Time.deltaTime));
        }

        if (moveInput.x > 0.1)
        {
            transform.position = transform.position + (transform.right * (movementSpeed * Time.deltaTime));
        }

        if (moveInput.y > 0.1)
        {
            transform.position = transform.position + (transform.forward * (movementSpeed * Time.deltaTime));
        }

        if (moveInput.y < -0.1)
        {
            transform.position = transform.position + (-transform.forward * (movementSpeed * Time.deltaTime));
        }

        if (input.GoUp)
        {
            transform.position = transform.position + (transform.up * (movementSpeed * Time.deltaTime));
        }

        if (input.GoDown)
        {
            transform.position = transform.position + (-transform.up * (movementSpeed * Time.deltaTime));
        }

        /*if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp))
        {
            transform.position = transform.position + (Vector3.up * (movementSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown))
        {
            transform.position = transform.position + (-Vector3.up * (movementSpeed * Time.deltaTime));
        }*/

        if (looking)
        {
            float newRotationX = transform.localEulerAngles.y + input.LookInput.x * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - input.LookInput.y * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
        }

        /*float axis = Input.GetAxis("Mouse ScrollWheel");
        if (axis != 0)
        {
            var zoomSensitivity = fastMode ? this.fastZoomSensitivity : this.zoomSensitivity;
            transform.position = transform.position + transform.forward * (axis * zoomSensitivity);
        }*/

        if (input.DoLook)
        {
            StartLooking();
        }
        else
        {
            StopLooking();
        }
    }

    void OnDisable()
    {
        StopLooking();
    }

    /// <summary>
    /// Enable free looking.
    /// </summary>
    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        if (input.isMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    /// <summary>
    /// Disable free looking.
    /// </summary>
    public void StopLooking()
    {
        looking = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}