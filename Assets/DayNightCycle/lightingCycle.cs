/*The code used for the day and night cycle*/

using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways] // executes certain methods in this class while the game isn't running,
                // so that the changes can be seen while I am in the editor.
public class lightingCycle : MonoBehaviour
{

  // references to variables DirectionalLight and Preset
  [SerializeField] private Light DirectionalLight; // made visible in the inspector, using
                                                   // SerializeField
  [SerializeField] private lightingVariables Preset;
  // declaring variables for use in the lightingCycle class
  [SerializeField, Range (0,24)] public float TimeOfDay; // has a range of 0 to 24
  public Text timeOfDayOutput;
  public double TimeOfDayOutputNumber;
  public string TimeOfDayText;

  private void Start() { // the start method

    TimeOfDay = 5; // sets the time of day to 5am when the game starts

  }


  private void Update () // update method, used to update the lighting
  {
    if(Preset == null) { // check that the preset has been assigned
      return; // returns if not assigned
    }

      if (Application.isPlaying) { // if the application is playing,

          TimeOfDay += (Time.deltaTime * 0.1f);         // the time gets updated
          TimeOfDay %= 24;                              // divides the time by 24, because
                                                        // it is in the range of 0 to 24, but
                                                        // i want to pass in a value of between
                                                        // 0 and 1.

          if (Math.Floor(TimeOfDay) > 12) // if the time of day is greater than 12
          {
            TimeOfDayOutputNumber = Math.Floor(TimeOfDay) - 12; // take away 12 from the time of day
            TimeOfDayText = TimeOfDayOutputNumber + " PM";      // and add pm to the end. this is to add
                                                                // a usability feature so the time is more
                                                                // easily understood.
          }

          else if (Math.Floor(TimeOfDay) == 0) // if the hour number is 0, then the output is 12am
          {                                    // otherwise the output would be 0am which is not usable.
            TimeOfDayOutputNumber = 12;
            TimeOfDayText = TimeOfDayOutputNumber + " AM"; // add am to the end
          }

          else // if the time of day is not equal to 0 or greater than 12
          {

            if (Math.Floor(TimeOfDay) == 12) // if the time of day is equal to 12 in this case, then it is 12pm
              {
                TimeOfDayOutputNumber = Math.Floor(TimeOfDay);
                TimeOfDayText = TimeOfDayOutputNumber + " PM"; // add pm to the end
              }
              else {
              TimeOfDayOutputNumber = Math.Floor(TimeOfDay);
              TimeOfDayText = TimeOfDayOutputNumber + " AM"; // add am to the end
            }
          }

          UpdateLighting(TimeOfDay / 24f); // updates the lighting
          timeOfDayOutput.text = "WORLD TIME " + (TimeOfDayText); // outputs the world time

      } else {

          UpdateLighting(TimeOfDay / 24f); // updates the lighting
          timeOfDayOutput.text = "WORLD TIME " + (TimeOfDayText); // outputs the world time

      }
    }

// the method to change the lighting settings, depending on the time of day.
  private void UpdateLighting(float timePercentage) {

    // setting the render settings by evaluating all the different gradients in the preset
    RenderSettings.ambientLight = Preset.AmbientColour.Evaluate(timePercentage);
    RenderSettings.fogColor = Preset.FogColour.Evaluate(timePercentage);

    // setting up the directional light
    if(DirectionalLight != null) { // first checking if the directional light has been assigned

      DirectionalLight.color = Preset.DirectionalColour.Evaluate(timePercentage);
      DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercentage * 360f) - 90f, - 170f, 0));
      // changing the colour and rotation of the directional light
    }
  }

  private void OnValidate() // on validate method which is called every time the script
                            // is reloaded, or a variable in the inspector is changed.
  {
/* the purpose of this method is to check that if the directional light isn't set, it will
   get set to the sun directional light in the scene. This is validation for the directional
   light as it ensures it is set correctly.*/

    if (DirectionalLight != null) { // if the directional light is active
      return;
    }

    if (RenderSettings.sun != null) { // if the sun is active
      DirectionalLight = RenderSettings.sun;
    }

    else {

 /* furthermore, if the light variable isn't set then the program will search for it and assign
    it to the directional light. */
      Light[] lights = GameObject.FindObjectsOfType<Light>();
      foreach(Light light in lights) {

        if (light.type == LightType.Directional) {

          DirectionalLight = light;
          return;

        }
      }
    }
  }
}
