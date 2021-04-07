using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Vector3 _mainMenuPosition;
    [SerializeField]
    private float _sizeOnMainMenu;
    [SerializeField]
    private Vector3 _gamePosition;
    [SerializeField]
    private float _sizeOnGame;
    [SerializeField]
    private float _movementDurationInSeconds;
    [SerializeField]
    private float _zoomingDurationInSeconds;
    private Vector3 _targetPosition;
    private float _targetSize;
    private Camera _camera;
    private WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();
    private IEnumerator _moveCamera;
    private IEnumerator _zoomCamera;

    public void ChangeCameraToGameView()
    {
        _targetPosition = _gamePosition;
        _targetSize = _sizeOnGame;
        _moveCamera = MoveCameraToTargetPosition();
        _zoomCamera = ZoomCameraToTargetSize();
        StartCoroutine(_moveCamera);
        StartCoroutine(_zoomCamera);
    }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        SetCameraToMenuSettings();
    }

    private void SetCameraToMenuSettings()
    {
        transform.position = _mainMenuPosition;
        _camera.orthographicSize = _sizeOnMainMenu;
    }

    private IEnumerator ZoomCameraToTargetSize()
    {
        float differenceBetweenSizes = _targetSize - _camera.orthographicSize;
        while (_camera.orthographicSize != _targetSize)
        {
            _camera.orthographicSize += differenceBetweenSizes / _zoomingDurationInSeconds * Time.deltaTime;
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _camera.orthographicSize, _targetSize);
            Debug.Log("zoom camera");
            yield return _waitForEndOfFrame;
        }
    }

    private IEnumerator MoveCameraToTargetPosition()
    {
        float differenceBetweenPositions = Vector3.Distance(_targetPosition, transform.position);
        Vector3 currentPosition = transform.position;

        while (transform.position != _targetPosition)
        {
            currentPosition += Vector3.up * differenceBetweenPositions / _movementDurationInSeconds * Time.deltaTime;
            currentPosition.x = Mathf.Clamp(currentPosition.x, currentPosition.x, _targetPosition.x);
            currentPosition.y = Mathf.Clamp(currentPosition.y, currentPosition.y, _targetPosition.y);
            transform.position = currentPosition;
            Debug.Log("move camera");
            yield return _waitForEndOfFrame;
        }
    }
}
