using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Zenject;

public class SingleArrowCompass : BaseCompass
{
    [SerializeField] private List<BaseCompassMarker> _markers = new List<BaseCompassMarker>();
    [SerializeField] private BaseCompassArrow _arrow;
    [SerializeField] private float _maxArrowRadius;
    [SerializeField] private float _minArrowRadius;
    [SerializeField] private float _smoothness;

    private BaseCompassMarker _closestMarker;
    private Transform _playerTransform;
    private Transform _arrowTransform;
    private float _resortInterval = 0.5f;

    [Inject]
    public void Construct(PlayerHealth player)
    {
        _playerTransform = player.transform;
        _arrowTransform = _arrow.transform;
        _arrow.HideMarker();
    }

    void Start()
    {
        StartCoroutine(resortMarkerList());
    }

    void FixedUpdate()
    {
        updateArrows();
    }

    public override void Register(BaseCompassMarker newMarker)
    {
        _markers.Add(newMarker);
    }

    public override void Unregister(BaseCompassMarker newMarker)
    {
        BaseCompassMarker registredMarker = _markers.Find(x => x == newMarker);
        if (registredMarker == null)
        {
            Debug.LogError($"Не могу удалить маркер \'{newMarker.ToString()}\' т.к. его нет среди отслеживаемых маркеров. Используй метод Register");
            return;
        }
        _markers.Remove(newMarker);
    }

    protected override void updateArrows()
    {
        if (_markers.Count == 0 || _playerTransform == null)
        {
            _arrow.HideMarker();
            return;
        }
        _arrow.ShowMarker();
        BaseCompassMarker marker = _closestMarker != null ? _closestMarker : _markers[0];

        Vector3 directionToMarker = marker.transform.position - _playerTransform.position;
        directionToMarker.y = _playerTransform.position.y;
        float distance = directionToMarker.magnitude;
        Vector3 resultMarkerPosition;
        if (distance < _minArrowRadius)
        {
            resultMarkerPosition = directionToMarker * 100;
            _arrow.HideMarker();           
        }
        else if (distance > _maxArrowRadius)
        {
            resultMarkerPosition = _playerTransform.position + directionToMarker.normalized * _maxArrowRadius;
        }
        else
        {
            resultMarkerPosition = marker.transform.position;
        }
        Quaternion targetRot = Quaternion.LookRotation(directionToMarker.normalized);

        _arrow.DistanceToMarker = distance;
        _arrowTransform.transform.position = Vector3.Lerp(_arrowTransform.transform.position, 
                                                          resultMarkerPosition, 
                                                          Time.fixedDeltaTime * _smoothness);
        _arrowTransform.rotation = Quaternion.Lerp(_arrowTransform.rotation, 
                                                   targetRot,
                                                   Time.fixedDeltaTime * _smoothness);
    }

    private IEnumerator resortMarkerList()
    {
        float elapsed = 0;
        while(true)
        {
            elapsed += Time.deltaTime;
            if(elapsed > _resortInterval)
            {
                elapsed = 0;
                if (_markers.Count == 0 || _playerTransform == null) continue;

                foreach (BaseCompassMarker marker in _markers)
                {
                    marker.DistanceToCompass = Vector3.Distance(_playerTransform.position, marker.transform.position);
                }
                _markers.Sort((x, y) => (int)(x.DistanceToCompass - y.DistanceToCompass));
                _closestMarker = _markers[0];
                _arrow.MarkerText = _closestMarker.MarkerLabel;
            }            
            yield return null;
        }        
    }
}
