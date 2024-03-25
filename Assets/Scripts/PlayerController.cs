using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
    private Rigidbody rb;
	private int count_batteries;
	private int total_batteries = 10;
    private float wintext_time = 7.0f;

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
        if (count_batteries >= total_batteries) {             
			winText.text = "You Win!";
		    wintext_time -= Time.deltaTime;
		    if (wintext_time <= 0.0f) { SceneManager.LoadScene("MainMenu"); }
        }

    }

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
            count_batteries++;
			SetCountText();
            GetComponent<AudioSource>().Play();
        }
	}

	void SetCountText()
	{
		countText.text = "Batteries: " + (total_batteries - count_batteries).ToString();
	}
}