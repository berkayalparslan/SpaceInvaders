using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpaceshipsRow : MonoBehaviour
{
    private static Stack<SpaceshipType> _typesRandomlySorted = new Stack<SpaceshipType>();
    private static Stack<SpaceshipColor> _colorsRandomlySorted = new Stack<SpaceshipColor>();
    private static float _timeBetweenVerticalMovements;
    private const float _minDefaultTimeBetweenVerticalMovements = 5f;
    private const float _maxDefaultTimeBetweenVerticalMovements = 10f;
    private const float _leftBorder = -30f;
    private const float _rightBorder = 30f;
    private const int _numberOfSpaceshipsInRow = 10;
    private readonly Vector2 _defaultMovementSpeed = new Vector2(1, 1);

    private List<AiSpaceship> _spaceships = new List<AiSpaceship>();
    private float _maxDistanceFromOriginPerSpaceship;
    private Vector2 _currentMovementSpeedForSpaceshipsInThisRow;
    private SpaceshipColor _rowSpaceshipColor;
    private SpaceshipType _rowSpaceshipType;

#if UNITY_EDITOR
    public int DEBUG_NumberOfSpaceshipsInRow;
#endif

    public static float TimeBetweenVerticalMovements
    {
        get
        {
            return _timeBetweenVerticalMovements;
        }
    }

    public SpaceshipColor SpaceshipColorOnThisRow
    {
        get
        {
            return _rowSpaceshipColor;
        }
    }

    public SpaceshipType SpaceshipTypeOnThisRow
    {
        get
        {
            return _rowSpaceshipType;
        }
    }


    public void InitRow()
    {
        int numberofSpaceshipsInRow;
#if UNITY_EDITOR
        numberofSpaceshipsInRow = DEBUG_NumberOfSpaceshipsInRow != 0 ? DEBUG_NumberOfSpaceshipsInRow : _numberOfSpaceshipsInRow;
#else
        numberofSpaceshipsInRow = _numberOfSpaceshipsInRow;
#endif
        SetRowSpaceshipColor();
        SetRowSpaceshipType();
        FillSlotsWithSpaceships(numberofSpaceshipsInRow);
    }

    private void Start()
    {
        SortAndSetSpaceshipColorsRandomly();
        SortAndSetSpaceshipTypesRandomly();
        SetTimeBetweenVerticalMovementsRandomly();
    }

    private void OnDestroy()
    {
        _colorsRandomlySorted.Clear();
        _typesRandomlySorted.Clear();
    }

    private void SortAndSetSpaceshipColorsRandomly()
    {
        List<SpaceshipColor> spaceshipsColors = new List<SpaceshipColor>(SpaceshipHelper.GetSpaceshipColors());
        int randomIndex = 0;

        _colorsRandomlySorted.Clear();
        spaceshipsColors.Remove(Managers.Instance.PlayerManager.PlayerSpaceshipColor);

        while (spaceshipsColors.Count > 0)
        {
            randomIndex = Random.Range(0, spaceshipsColors.Count);
            _colorsRandomlySorted.Push(spaceshipsColors[randomIndex]);
            spaceshipsColors.RemoveAt(randomIndex);
        }
    }

    private void SortAndSetSpaceshipTypesRandomly()
    {
        List<SpaceshipType> spaceshipsTypes = new List<SpaceshipType>(SpaceshipHelper.GetSpaceshipTypes());
        int randomIndex = 0;

        _typesRandomlySorted.Clear();
        spaceshipsTypes.Remove(Managers.Instance.PlayerManager.PlayerSpaceshipType);

        while (spaceshipsTypes.Count > 0)
        {
            randomIndex = Random.Range(0, spaceshipsTypes.Count);
            _typesRandomlySorted.Push(spaceshipsTypes[randomIndex]);
            spaceshipsTypes.RemoveAt(randomIndex);
        }
    }

    private void SetRowSpaceshipColor()
    {
        if (_colorsRandomlySorted.Count == 0)
        {
            SortAndSetSpaceshipColorsRandomly();
        }
        _rowSpaceshipColor = _colorsRandomlySorted.Pop();
    }

    private void SetRowSpaceshipType()
    {
        if (_typesRandomlySorted.Count == 0)
        {
            SortAndSetSpaceshipTypesRandomly();
        }
        _rowSpaceshipType = _typesRandomlySorted.Pop();
    }

    private void FillSlotsWithSpaceships(int numberOfSpaceships)
    {
        ObjectPool spaceshipsPool = Managers.Instance.SpaceshipsPool;
        GameObject spaceshipFromPool = null;
        AiSpaceship aiSpaceship = null;
        Vector3 origin;
        CalculateMaxDistanceFromOriginForSpaceshipsInThisRow(numberOfSpaceships);
        CalculateNewMovementSpeedForSpaceshipsInThisRow(numberOfSpaceships);

        for (int i = 0; i < numberOfSpaceships; i++)
        {
            spaceshipFromPool = spaceshipsPool.GetPoolObject();

            if (spaceshipFromPool != null)
            {
                aiSpaceship = spaceshipFromPool.GetComponent<AiSpaceship>();

                if (aiSpaceship != null)
                {
                    origin = GetOriginPositionByIndex(i, transform);
                    aiSpaceship.InitSpaceshipBeforeActivating(this, origin, transform.rotation, _maxDistanceFromOriginPerSpaceship, _currentMovementSpeedForSpaceshipsInThisRow);
                    aiSpaceship.OnSpaceshipDisable += OnSpaceshipDisabled;
                    _spaceships.Add(aiSpaceship);
                }
            }
        }
    }

    private Vector3 GetOriginPositionByIndex(int index, Transform transformForXZAxis)
    {
        return new Vector3(_leftBorder + _maxDistanceFromOriginPerSpaceship * (index + 1) + (index * _maxDistanceFromOriginPerSpaceship), transformForXZAxis.position.y, transform.position.z);
    }

    private void OnSpaceshipDisabled(AiSpaceship aiSpaceship)
    {
        aiSpaceship.OnSpaceshipDisable -= OnSpaceshipDisabled;
        _spaceships.Remove(aiSpaceship);
        CalculateMaxDistanceFromOriginForSpaceshipsInThisRow(_spaceships.Count);
        CalculateNewMovementSpeedForSpaceshipsInThisRow(_spaceships.Count);
        UpdateSpaceships();
    }

    private void CalculateMaxDistanceFromOriginForSpaceshipsInThisRow(int numberOfSpaceships)
    {
        _maxDistanceFromOriginPerSpaceship = Mathf.Abs(_rightBorder - _leftBorder) / numberOfSpaceships * 0.5f;
    }

    private void CalculateNewMovementSpeedForSpaceshipsInThisRow(int numberOfSpaceships)
    {
        Vector2 movementSpeed;
        movementSpeed.x = _defaultMovementSpeed.x + (3 - (numberOfSpaceships / 10f)) * 2f;
        movementSpeed.y = _defaultMovementSpeed.y + (3 - (numberOfSpaceships / 10f)) * 1.5f;
        _currentMovementSpeedForSpaceshipsInThisRow = movementSpeed;
    }

    private void UpdateSpaceships()
    {
        AiSpaceship spaceship = null;
        Vector3 origin;

        for (int i = 0; i < _spaceships.Count; i++)
        {
            spaceship = _spaceships[i];
            origin = GetOriginPositionByIndex(i, spaceship.transform);
            spaceship.SetHorizontalMovementBorders(origin, _maxDistanceFromOriginPerSpaceship);
            spaceship.SetMovementSpeed(_currentMovementSpeedForSpaceshipsInThisRow);
        }
    }

    private static void SetTimeBetweenVerticalMovementsRandomly()
    {
        _timeBetweenVerticalMovements = Random.Range(_minDefaultTimeBetweenVerticalMovements, _maxDefaultTimeBetweenVerticalMovements);
    }
}
