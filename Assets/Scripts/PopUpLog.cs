 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 
 // put this script on any gameobject, i personally use an empty 'root' gameobject on which i put all my scripts alike
 public class PopUpLog : MonoBehaviour {
     public Canvas Log;    // now you have to drag and drop your canvas in the editor in the script component
     private bool logActive = false; // do we have to display the canvas (true) or not (false)
     
     void Update () {
         if(Input.GetKeyDown(Keycode.J)){ // if you press the E key
            logActive = !doorActive; // change the state of your bool
            Log.transform.SetActive(logActive); // display or not the canvas (following the state of the bool)
         }
     }
 }
