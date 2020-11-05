using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

	public Camera ourCamera;
	public Rigidbody ourRigidbody;
	public CapsuleCollider ourCollider;

	public float MinimumY;
	public float MaximumY;

	float currentUpDownLookRotation = 0f;

	public float jumpForce = 3f;

	public float lookSensitivity;

	public float movementSpeed;
	public float sprintModifier;
	public Vector3 maxSpeed;

	public bool isLocalPlayer = true;
	private Vector3 movementThisFrame;

	public GravityAffectedPlayer ourGravityPlayer;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}

	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer) {

			ourCamera.enabled = false;

			return;

		}

		movementThisFrame = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		Vector2 mouseLook = new Vector2 (Input.GetAxis ("Mouse X"), -Input.GetAxis ("Mouse Y"));
		currentUpDownLookRotation += (mouseLook.y * lookSensitivity);
		currentUpDownLookRotation = Mathf.Clamp (currentUpDownLookRotation, MinimumY, MaximumY);

		transform.RotateAround (ourCamera.transform.parent.position, this.transform.up, mouseLook.x * lookSensitivity);

		ourCamera.transform.localRotation = Quaternion.Euler (currentUpDownLookRotation, ourCamera.transform.localRotation.eulerAngles.y, ourCamera.transform.localRotation.eulerAngles.z);

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded ()) {

			ourRigidbody.AddForce (this.transform.up * jumpForce, ForceMode.VelocityChange);

		}

	}

	void FixedUpdate () {

		Vector3 oldVel = transform.InverseTransformDirection (ourRigidbody.velocity);

		Vector3 newVel = new Vector3 (movementThisFrame.x, 0, movementThisFrame.z);

		if (newVel == Vector3.zero) {
			newVel = oldVel;
			newVel.x /= -2;
			newVel.y = 0;
			newVel.z /= -2;
		} else if (newVel.x == 0) {
			newVel.x = oldVel.x / -2;
		} else if (newVel.z == 0) {
			newVel.z = oldVel.z / -2;
		}

		ourRigidbody.AddForce (transform.TransformDirection (newVel), ForceMode.VelocityChange);

		newVel = transform.InverseTransformDirection (ourRigidbody.velocity);
		if (newVel.x > 5) newVel.x = 5;
		if (newVel.x < -5) newVel.x = -5;
		if (newVel.z > 5) newVel.z = 5;
		if (newVel.z < -5) newVel.z = -5;
		ourRigidbody.velocity = transform.TransformDirection (newVel);

		ourRigidbody.angularVelocity = Vector3.zero;

		if (ourGravityPlayer != null && ourGravityPlayer.planetCollider != null) {
			ourRigidbody.AddForce ((ourGravityPlayer.planetCollider.transform.position - transform.position).normalized * 9.81f, ForceMode.Acceleration);

		}

		Debug.DrawLine (transform.position, transform.position + ourRigidbody.velocity, Color.blue, 0.1f);
	}

	bool isGrounded () {

		if (ourGravityPlayer.planetCollider == null) return false;

		RaycastHit hit;

		Physics.Raycast (transform.position, ourGravityPlayer.planetCollider.transform.position - transform.position, out hit, 1.1f);

		return hit.collider;

	}
}