using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{

    // Start is called before the first frame update
    Resolution[] resolutions; //an array to store our possible screen resolutions

    public Dropdown resolutionDropdown; // our dropdown menu
    
    void Start () {
        
        resolutions = Screen.resolutions; //stores the possible screen resolutions in our "resolutions" array

        resolutionDropdown.ClearOptions();

        List<string> options = new List <string>(); // creates a list of options which will store our dropdown list of resolutions

        int currentResolutionIndex = 0; 

        for (int i = 0; i < resolutions.Length; i++){ //for loop to iterate through the list of possible resolutions

            string option = resolutions[i].width + " × " + resolutions[i].height;
            options.Add(option); // puts the contents of the array into strings

             /*if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height){*/

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height){ //if the browsed resolution is equal to the current resolution....

                currentResolutionIndex = i; //automatically set the resolution to the best avaialable
            }
        }

        resolutionDropdown.AddOptions(options); //adds the content of the "options" list to our dropdown 
        resolutionDropdown.value = currentResolutionIndex; //sets the resolution value in our dropdown to the current resolution
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex){ //method to finally set our resolution

        Resolution resolution = resolutions[resolutionIndex]; 
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //sets our resolution and sets the screen to fullscreen
    }
    
    public void setFullScreen(bool isFullscreen){ //method to toggle fullscreen

        Screen.fullScreen = isFullscreen; // sets boolean "isFullscreen" to true
    }
    
}
