using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SpinWheel : MonoBehaviour
{
	public List<int> prize;
	public List<AnimationCurve> animationCurves;
	
	private bool spinning;	
	private float anglePerItem;	
	private int randomTime;
	private int itemNumber; 
	
	void Start(){
		spinning = false;
		anglePerItem = 360/prize.Count;		
	}
	
	void  Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && !spinning) { //spins the wheel when the spacebar is pressed
		
			randomTime = Random.Range (1, 4);
			itemNumber = Random.Range (1, prize.Count); //sets the item which will be under the arrow when the wheel stops
			float maxAngle = 360 * randomTime + (itemNumber * anglePerItem); //denotes what the final angle will be. Yes we'll know the result before spinning the wheel
			
			StartCoroutine (SpinTheWheel (5 * randomTime, maxAngle));  //starts the coroutine "SpinTheWheel"
		}

			if(Input.GetKeyDown(KeyCode.Escape)){ 

			//Debug.Log("Escape to main menu");

			SceneManager.LoadScene(0); //goes back to the main menu when the "Escape" button is pressed

			
		}
	}
	
	IEnumerator SpinTheWheel (float time, float maxAngle) //coroutine call that contains two random numbers
	{
		spinning = true;

		//the timer, startAngle and maxAngle are initialized
		float timer = 0.0f;		
		float startAngle = transform.eulerAngles.z;		
		maxAngle = maxAngle - startAngle;
		
		int animationCurveNumber = Random.Range (0, animationCurves.Count); // an animation curve is selected, we only have one in our case. Value can be changed in the inspector
		Debug.Log ("Animation Curve No. : " + animationCurveNumber);
		
		while (timer < time) {
		//to calculate rotation
			float angle = maxAngle * animationCurves [animationCurveNumber].Evaluate (timer / time) ;
			transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle + startAngle);
			timer += Time.deltaTime;
			yield return 0;
		}
		
		transform.eulerAngles = new Vector3 (0.0f, 0.0f, maxAngle + startAngle);
		spinning = false;
			
		Debug.Log ("Prize: " + prize [itemNumber]);//use prize[itemNumnber] as per requirement
	}

	

	
	
}
