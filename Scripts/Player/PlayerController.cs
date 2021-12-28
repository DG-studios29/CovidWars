using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
	//public CharacterController controller;
	//public float speed = 15f;
	//public float jumpHeight = 3f;
	//Vector3 velocity;
	//public float gravity = -19.62f;
	public Transform groundContact;
	public float ground = 0.15f;
	public LayerMask groundLayer;
	public bool isGrounded;
	HashTable<Items> inventorySystem;
	List<Sprite> itemImage;
	public GameObject ItemSlots;
	public GameObject InventoryPanel;
	List<GameObject> itemsPickUp;
	public List<Items> walkToItems = new List<Items>();
	public NavMeshAgent agent;
	GameObject CurrentNPC;
	public GameObject Portal;
	bool isWalking = false;
	static Animator anim;
	public AudioClip itemPickup;

	private void Start( )
	{
		itemsPickUp = new List<GameObject>();
		itemImage = new List<Sprite>();
		inventorySystem = new HashTable<Items>(9);
		anim = GetComponent<Animator>();
		//agent = this.GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update( )
	{
		if (isWalking)
		{
			Movement(CurrentNPC.transform.position);
			anim.SetBool("playerIsWalk", true);
			anim.SetBool("isTalking", false);
			if (Vector3.Distance(this.transform.position, CurrentNPC.transform.position) <= 5)
			{
				isWalking = false;
				CurrentNPC.GetComponent<Npc>().TriggerDialogue();
				anim.SetBool("playerIsWalk", false);
				anim.SetBool("isTalking", true);
			}

		}
		else if(agent.velocity == Vector3.zero)
		{
			anim.SetBool("playerIsWalk", false);
		}
		else
		{
			anim.SetBool("playerIsWalk", true);
		}



		//isGrounded = Physics.CheckSphere(groundContact.position, ground, groundLayer);

		//if (isGrounded && velocity.y < 0)
		//{
		//	velocity.y = -2f;
		//}

		//float x = Input.GetAxis("Horizontal");
		//float z = Input.GetAxis("Vertical");

		//Vector3 move = transform.right * x + transform.forward * z;

		//controller.Move(move * speed * Time.deltaTime);

		//if (Input.GetButtonDown("Jump") && isGrounded)
		//{
		//	velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
		//}


		//velocity.y += gravity * Time.deltaTime;

		//controller.Move(velocity * Time.deltaTime);


		//if (Input.GetKeyDown(KeyCode.I))
		//{

		//	Items temp = SearchInventory("WATCH");

		//}
	}
	public void addToInventory(Items item)
	{

		if (inventorySystem.Insert(item.itemName, item))
		{
			itemImage.Add(item.icon);
			updateInventoryUI();
		}

	}

	public Items SearchInventory(string itemName)
	{

		Items tempItem = inventorySystem.Search(itemName);
		return tempItem;


	}
	public void updateInventoryUI( )
	{
		foreach (GameObject game in itemsPickUp)
		{
			Destroy(game);
			AudioSource.PlayClipAtPoint(itemPickup, transform.position);
		}

		foreach (Sprite item in itemImage)
		{
			GameObject updateMethod = Instantiate(ItemSlots, InventoryPanel.transform);
			updateMethod.SetActive(true);

			Transform slot = updateMethod.transform.GetChild(0);
			Transform image = slot.GetChild(0);
			image.GetComponent<Image>().sprite = item;
			itemsPickUp.Add(updateMethod);
		}
	}
	public void deleteFromInventory(string itemToDelete)
	{
		inventorySystem.Remove(itemToDelete);
		updateInventoryUI();
	}
	public void deleteFromInventory(Items itemToDelete)
	{
		inventorySystem.Remove(itemToDelete.itemName);
		updateInventoryUI();

	}
	public void WalkToItem( )
	{
		GameObject[] itemsInScene = GameObject.FindGameObjectsWithTag("item");
		foreach (GameObject item in itemsInScene)
		{
			if (walkToItems[0] == item.GetComponent<Items>())
			{
				Movement(item.transform.position);
				
			}

		}



	}
	public void Movement(Vector3 moveToPos)
	{
		agent.SetDestination(moveToPos);
	}
	public void WalkToNPC(Npc npcWalkTO)
	{
		CurrentNPC = npcWalkTO.gameObject;
		isWalking = true;

	}
	public void WalkToPotal( )
	{
		Portal = GameObject.FindGameObjectWithTag("Portal1");
		Movement(Portal.transform.position);
	}
}
