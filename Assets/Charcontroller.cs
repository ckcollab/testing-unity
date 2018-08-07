using UnityEngine;
using System.Collections;

public class Charcontroller : MonoBehaviour {

    [SerializeField]
    float move_speed = 4f;

    Vector3 forward, right;

	// Use this for initialization
	void Start () {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.anyKey)
        {
            Move();
        }
	}

    void Move() {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 right_movement = right * move_speed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 up_movement = forward * move_speed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(right_movement + up_movement);

        transform.forward = heading;
        transform.position += right_movement;
        transform.position += up_movement;
    }
}
