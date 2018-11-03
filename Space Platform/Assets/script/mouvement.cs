using UnityEngine;

public class mouvement : MonoBehaviour {

    public Controller control;

    public float runSpeed = 40f;
    float HorizontalMove = 0f;
    bool jump;

	void Update ()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }
	}

    void FixedUpdate()
    {
        control.Move(HorizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
