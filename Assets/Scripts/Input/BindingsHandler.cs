using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class BindingsHandler : MonoBehaviour
{ 
    [SerializeField] protected InputMap keyBindings;
    [SerializeField] protected string pathToBindings;
    [SerializeField] protected bool overwirteHandlerBindings = true;
    protected InputHandler handler;

    protected virtual void Start()
    {
        handler = GetComponent<InputHandler>();
        keyBindings = new InputMap("");
        if(overwirteHandlerBindings) 
            handler.SetInputMap(keyBindings);
    }
}
