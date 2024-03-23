using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	private int count_batteries;
	private int total_batteries = 10;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
        count_batteries = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
		if (rb.position.y < -10)
		{
            rb.position = new Vector3 (0.0f, 0.0f, 0.0f);
            rb.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
        }
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
            count_batteries++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Batteries: " + (total_batteries - count_batteries).ToString();
		if (count_batteries >= total_batteries)
		{
			winText.text = "You Win!";
		}
	}
}