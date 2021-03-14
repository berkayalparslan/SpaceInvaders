using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpaceshipsRow : MonoBehaviour
{
    private List<Transform> _slots = new List<Transform>();
    private SpaceshipColor _rowColor;
    private SpaceshipType _rowSpaceshipType;

    public int SlotsCount
    {
        get
        {
            return _slots.Count;
        }
    }

    public SpaceshipColor SpaceshipColorOnThisRow
    {
        get
        {
            return _rowColor;
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
        SetRowColorRandomly();
        SetRowSpaceshipTypeRandomly();
        FillSlotsWithSpaceships();
    }

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _slots.Add(transform.GetChild(i));
        }
    }

    private void SetRowColorRandomly()
    {
        int spaceshipColorMinValue = (int) SpaceshipHelper.GetSpaceshipColorMinValue();
        int spaceshipColorMaxValue = (int) SpaceshipHelper.GetSpaceshipColorMaxValue();
        _rowColor = (SpaceshipColor)Random.Range(spaceshipColorMinValue, spaceshipColorMaxValue + 1);
    }

    private void SetRowSpaceshipTypeRandomly()
    {
        int spaceshipTypeMinValue = (int)SpaceshipHelper.GetSpaceshipTypeMinValue();
        int spaceshipTypeMaxValue = (int)SpaceshipHelper.GetSpaceshipTypeMaxValue();
        _rowSpaceshipType = (SpaceshipType)Random.Range(spaceshipTypeMinValue, spaceshipTypeMaxValue + 1);
    }

    private void FillSlotsWithSpaceships()
    {
        ObjectPool spaceshipsPool = Managers.Instance.SpaceshipsPool;
        ResourcesManager resourcesManager = Managers.Instance.ResourcesManager;

        foreach (Transform slot in _slots)
        {
            GameObject spaceship = spaceshipsPool.GetPoolObject();

            if (spaceship != null)
            {
                AiSpaceship aiSpaceship = spaceship.GetComponent<AiSpaceship>();

                if (aiSpaceship != null)
                {
                    aiSpaceship.InitSpaceshipBeforeActivating(this, slot);
                }
            }
        }
    }
}
