using UnityEngine;
using Zenject;

public class StartTable : MonoBehaviour
{
    [SerializeField] private GameObject _vobla;
    private VoblaLineHandler _lineHandler;
    private VoblaRunAnimation _runAnimation;
    private WorldMotor _motor;

    [Inject]
    public void Construct(WorldMotor motor)
    {
        _motor = motor;
        _motor.AddSceneObject(transform);
    }
    public void SetVobla(GameObject vobla)
    {
        _vobla = vobla;
    }
    // Start is called before the first frame update
    void Start()
    {
        _lineHandler = _vobla.GetComponent<VoblaLineHandler>();
        _runAnimation = _vobla.GetComponent<VoblaRunAnimation>();
        _lineHandler.enabled = false;
        _runAnimation.enabled = false;
    }
}
