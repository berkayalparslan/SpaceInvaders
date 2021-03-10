using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpaceshipsRow : MonoBehaviour
{
    private List<Transform> _slots = new List<Transform>();
    private SpaceshipColor _rowColor;

    public int SlotsCount
    {
        get
        {
            return _slots.Count;
        }
    }


    public void InitRow()
    {
        SetRowColorRandomly();
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
        _rowColor = (SpaceshipColor)Random.Range((int)SpaceshipColor.Blue, (int)SpaceshipColor.Yellow + 1);
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
                SpaceshipAppearance appearance = spaceship.GetComponentInChildren<SpaceshipAppearance>();
                AiMovement aiMovement = spaceship.GetComponent<AiMovement>();
                float slotPositionOnX = slot.transform.position.x;

                if (appearance != null)
                {
                    Sprite sprite = resourcesManager.GetSpriteBySpaceshipTypeAndColor(SpaceshipType.Default, _rowColor);
                    appearance.SetSprite(sprite);
                }

                if (aiMovement != null)
                {
                    aiMovement.SetMinAndMaxHorizontalPositions(slotPositionOnX - 3f, slotPositionOnX + 3f);
                }
                spaceship.transform.position = slot.position;
                spaceship.transform.rotation = slot.rotation;
                spaceship.SetActive(true);
            }
        }
    }
}
