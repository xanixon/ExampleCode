using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleVoblaLineHandler : VoblaLineHandler
{
    [SerializeField] private float _transitionSpeed = 1;
    [SerializeField] private float _jumpForce = 10;

    private Transform tr;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        currentLine = 1;
        tr = transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lineControl(currentLine);
        tempInputHandler();
    }

    public override void changeLine(int direction)
    {
        if (direction < 0) 
            currentLine--;
        else if(direction > 0) 
            currentLine++;
        currentLine = Mathf.Clamp(currentLine, 0, lineCount - 1);
    }

    protected override void lineControl(int line)
    {
        tr.position = Vector3.Lerp(tr.position, 
                                   new Vector3(line * lineWidth, tr.position.y, tr.position.z), 
                                   _transitionSpeed * Time.deltaTime);
    }

    protected void tempInputHandler()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * _jumpForce, ForceMode.VelocityChange);
        }
        float hor = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.A))
            changeLine(-1);
        if (Input.GetKeyDown(KeyCode.D))
            changeLine(1);
    }
}
