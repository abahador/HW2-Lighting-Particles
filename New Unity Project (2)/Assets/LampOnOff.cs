using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LampOnOff : MonoBehaviour
{
    // create camera list that can be updated in the inspector
    public Light Lamp;

    // create frame and button variables 
    private VisualElement frame;
    private Button button;

    // This function is called when the object becomes enabled and active.
    void OnEnable()
    {
        // get the UIDocument component (make sure this name matches!)
        var uiDocument = GetComponent<UIDocument>();
        // get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");
        // get the button, which is nested in the frame
        button = frame.Q<Button>("Button");
        // create event listener that calls ChangeCamera() when pressed
        button.RegisterCallback<ClickEvent>(ev => ChangeLight());
    }

    // initialize click count
    float click = 0f;
    private void ChangeLight()
    {
        Lamp.intensity = click * 0.4f;
        click++;
        // reset counter so it is not out of bounds (only have 4 cameras)
        if(click > 2){
            click = 0;
        }
    }

   

    
    
}
