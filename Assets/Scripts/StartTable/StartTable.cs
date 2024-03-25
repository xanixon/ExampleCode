using UnityEngine;
using Zenject;

public class StartTable : MonoBehaviour
{
    [SerializeField] private Transform _cameraStartPosition;
    [SerializeField] private Transform _lookAtPoint;
    private VoblaLineHandler _lineHandler;
    private VoblaRunAnimation _runAnimation;
    private WorldMotor _motor;
    private GameObject _vobla;

    [Inject]
    public void Construct(WorldMotor motor, 
                         [Inject(Id = "Vobla")] GameObject vobla,
                         CameraController camera)
    {
        _motor = motor;
        _motor.AddSceneObject(transform);
        _vobla = vobla;
        _lineHandler = _vobla.GetComponent<VoblaLineHandler>();
        _runAnimation = _vobla.GetComponent<VoblaRunAnimation>();
        _lineHandler.enabled = false;
        _runAnimation.enabled = false;
        camera.SetTarget(_lookAtPoint);
        camera.transform.position = _cameraStartPosition.position;
        camera.SetLookAtFlag(true);
    }
 
}
