using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;
    bool canMove = true;

    private void Start ()
    {
        UpgradeShopTrigger upgradeShopTrigger = GameObject.Find("ShopTrigger").GetComponent<UpgradeShopTrigger>();
        upgradeShopTrigger.UpgradeShopEnterEvent += disableMovement;
        upgradeShopTrigger.UpgradeShopEnterExit += enableMovement;
    }

    void disableMovement ()
    {
        canMove = false;
    }

    void enableMovement ()
    {
        canMove = true;
    }

	void Awake() 
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
        if(canMove) {
            float h = Input.GetAxisRaw("MoveHorizontal");
            float v = Input.GetAxisRaw("MoveVertical");

            Move(h, v);
            Turning();
            Animating(h, v);
        }
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
	}


	void Turning() 
	{
		if (ControlsManager.controllerEnabled) {
			float h = Input.GetAxisRaw ("CameraHorizontal");
			float v = Input.GetAxisRaw ("CameraVertical");
			Vector3 rotationVector = new Vector3 (h, 0f, v * -1); // Invert Vertical Axis

			if (rotationVector != Vector3.zero) {
				Quaternion newRotation = Quaternion.LookRotation(rotationVector);
				playerRigidbody.MoveRotation (newRotation);
			}

		} else {
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit floorHit;

			if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
			{
				Vector3 playerToMouse = floorHit.point - transform.position;
				playerToMouse.y = 0f;

				Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
				playerRigidbody.MoveRotation (newRotation);
			}
		}

	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}

