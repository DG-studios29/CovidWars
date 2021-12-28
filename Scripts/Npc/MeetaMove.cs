using UnityEngine;

public class MeetaMove : MonoBehaviour
{
	public float speed = 5f;
	public Transform[] moveSpots;
	private int randomSpot;
	public float waitTime;
	public float startTime;
	static Animator anim;
	public bool walking = true;
	public GameObject player;


	// Use this for initialization
	void Start( )
	{
		player = GameObject.Find("Player");
		anim = GetComponent<Animator>();
		GameObject[] movement = GameObject.FindGameObjectsWithTag("Meeta");
		moveSpots = new Transform[movement.Length];
		for (int i = 0; i < movement.Length; i++)
		{
			moveSpots[i] = movement[i].transform;
		}
		randomSpot = Random.Range(0, moveSpots.Length);
		anim.SetBool("isWalk", true);
	}

	// Update is called once per frame
	void Update( )
	{
		Transform temp = moveSpots[randomSpot];
		temp.position = new Vector3(moveSpots[randomSpot].position.x, transform.position.y, moveSpots[randomSpot].position.z);
		transform.LookAt(temp);
		//Quaternion tempQu = transform.localRotation;
		//tempQu.y += 180;
		//transform.localRotation = tempQu;
		//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
		transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
		if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
		{
			if (waitTime <= 0)
			{
				anim.SetBool("isWalk", true);
				randomSpot = Random.Range(0, moveSpots.Length);
				waitTime = startTime;
				startTime = 0;
			}
			else
			{
				anim.SetBool("isWalk", false);
				waitTime -= Time.deltaTime;
				startTime = 30f;
				transform.LookAt(player.transform);

			}


		}
	}


}

