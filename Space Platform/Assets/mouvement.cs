using UnityEngine;

public class mouvement : MonoBehaviour {

    public Controller control;

    public float runSpeed = 40f;
    float HorizontalMove = 0f;

	void Update ()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
	}

    void FixedUpdate()
    {
        control.Move(HorizontalMove * Time.fixedDeltaTime, false, false);
    }

}
