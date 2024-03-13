using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class BindingsHandler : MonoBehaviour
{ 
    [SerializeField] private InputMap keyBindings;
    [SerializeField] private string pathToBindings;
    [SerializeField] private bool overwirteHandlerBindings = true;
    private InputHandler handler;

    private void Start()
    {
        handler = GetComponent<InputHandler>();
        keyBindings = new InputMap("");
        if(overwirteHandlerBindings) 
            handler.SetInputMap(keyBindings);
    }
}
