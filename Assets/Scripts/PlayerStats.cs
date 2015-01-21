using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	//Moving stats
	public float speed;
	Vector3 startPoint;
	Vector3 endPoint;
	bool isMoving;
	float increment;

	//Walking Stats
	int walkCounter;
	int walkCounter2;
	int minWC2, maxWC2;
	bool isInCombat;

	//Cameras
	public GameObject cameraMain;
	public GameObject cameraCombat;

	// Use this for initialization
	void Start () {
		startPoint = transform.position;
		endPoint = transform.position;

		minWC2 = Random.Range( 5, 25 );
		maxWC2 = Random.Range( 25, 50 );
		walkCounter2 = Random.Range ( minWC2, maxWC2 );
	}

	// Update is called once per frame
	void Update () {
		AnimateSprite sprite = gameObject.GetComponent<AnimateSprite>();

		//Movement
		if(increment <= 1 && isMoving == true){
			increment += speed /100;
		}
		else{
			isMoving = false;
		}

		if(isMoving){
			transform.position = Vector3.Lerp(startPoint, endPoint, increment);
		}
		else{
			sprite.totalCells = 1;
		}

		if(!isInCombat){
			if(Input.GetKey("z") && isMoving == false){
				//Sprite operations
				sprite.rowNumber = 2;
				sprite.totalCells = 3;

				CalculateWalk();
				increment = 0;
				isMoving = true;
				startPoint = transform.position;
				endPoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
			}
			else if(Input.GetKey("s") && isMoving == false){
				sprite.rowNumber = 4;
				sprite.totalCells = 3;

				CalculateWalk();
				increment = 0;
				isMoving = true;
				startPoint = transform.position;
				endPoint = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
			}
			else if(Input.GetKey("d") && isMoving == false){
				sprite.rowNumber = 3;
				sprite.totalCells = 3;

				CalculateWalk();
				increment = 0;
				isMoving = true;
				startPoint = transform.position;
				endPoint = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
			}
			else if(Input.GetKey("q") && isMoving == false){
				sprite.rowNumber = 1;
				sprite.totalCells = 3;

				CalculateWalk();
				increment = 0;
				isMoving = true;
				startPoint = transform.position;
				endPoint = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
			}
		}
	}

	//Test if the number of steps as reached the limit before entering a fight
	void CalculateWalk(){
		if(walkCounter >= walkCounter2){
			minWC2 = Random.Range( 5, 25 );
			maxWC2 = Random.Range( 25, 50 );
			walkCounter2 = Random.Range(minWC2, maxWC2);
			walkCounter = 0;
			EnterCombat();
		}
		else{
			//if in tall grass
			walkCounter++;
		}
	}

	void EnterCombat(){
		cameraMain.SetActive(false);
		cameraCombat.SetActive(true);
		isInCombat = true;
		Debug.Log("Entering fight");
	}
}
