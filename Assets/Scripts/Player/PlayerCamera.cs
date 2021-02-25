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
    private float _movementSpeed;
    private Vector3 _targetPosition;
    private Camera _camera;


    public void StartMovingCameraToGamePosition()
    {
        _targetPosition = _gamePosition;
        StartCoroutine(MoveCameraToTargetPosition());
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

    private IEnumerator MoveCameraToTargetPosition()
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
            _camera.orthographicSize = Mathf.Lerp(_sizeOnMainMenu, _sizeOnGame, _movementSpeed * Time.deltaTime); ;
            yield return new WaitForEndOfFrame();
        }
    }
}
