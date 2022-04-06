using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	private float _horizontalMove;
	private bool _jump;
	private bool _crouch;

	private void Update () {
		if (Time.timeScale <= 0.5) return;
		_horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		if (Input.GetButtonDown("Jump"))
		{
			_jump = true;
			//animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch")) 
			_crouch = true;
		else if (Input.GetButtonUp("Crouch"))
			_crouch = false;

	}

	public void OnLanding ()
	{
		//animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		//animator.SetBool("IsCrouching", isCrouching);
	}

	private void FixedUpdate ()
	{
		controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
		_jump = false;
	}
}
