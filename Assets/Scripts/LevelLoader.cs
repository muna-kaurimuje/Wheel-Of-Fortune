using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

   
   public Animator transition; //getting access to our animator

   public float transitionTime = 1f;// variable that specifies wait time for LoadLevel coroutine. 1 is the default that can be changed in the inspector

   //update is called once per frame
   void update(){

       if(Input.GetMouseButtonDown(0)){
 
           LoadNextLevel();
       }


   }
   public void LoadNextLevel(){ // method that detects current scene and loads the scene immediately after it

    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

   }

   IEnumerator LoadLevel(int levelIndex){

       //play animation when "Start" trigger is triggered. "Start" is like a play button that starts the animation. The "start" trigger ia defined in the animator
       transition.SetTrigger("Start");


       
       yield return new WaitForSeconds(transitionTime);// waits a specified (transitionTime) time before loading the scene

       
       SceneManager.LoadScene(levelIndex); //loads scene with the level index that was passed in
   }

}
