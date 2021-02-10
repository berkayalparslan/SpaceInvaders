using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    private const int _numberOfColorsForEachSpaceship = 6;
    private const int _numberOfSpaceships = 6;
    private Dictionary<SpaceshipType, Dictionary<SpaceshipColor, Sprite>> _sprites;
    
    
    private void Awake()
    {
        InitSpaceshipSpritesDictionary();
        LoadSpaceshipsSprites();
    }

    private void InitSpaceshipSpritesDictionary()
    {
        _sprites = new Dictionary<SpaceshipType, Dictionary<SpaceshipColor, Sprite>>();

        for (int i = 0; i < 6; i++)
        {
            SpaceshipType currentType = (SpaceshipType)(i + 1);
            _sprites.Add(currentType, new Dictionary<SpaceshipColor, Sprite>());

            for (int j = 0; j < 6; j++)
            {
                _sprites[currentType].Add((SpaceshipColor)j, null);
            }
        }
    }

    private void LoadSpaceshipsSprites()
    {
        string spaceshipFoldersDirectory = "Sprites/Spaceships/PNG/Spaceships/{0}";
        string currentSpaceshipFolder = "";

        for (int currentSpaceshipNr = 0; currentSpaceshipNr < _numberOfSpaceships; currentSpaceshipNr++)
        {
            SpaceshipType currentType = (SpaceshipType)(currentSpaceshipNr + 1);
            currentSpaceshipFolder = string.Format(spaceshipFoldersDirectory, string.Format("{0:00}", currentSpaceshipNr+1));
            _sprites[currentType] = LoadSpritesByColorOnPath(currentSpaceshipFolder);
        }
    }

    private Dictionary<SpaceshipColor, Sprite> LoadSpritesByColorOnPath(string path)
    {
        Sprite[] spritesOnPath = Resources.LoadAll<Sprite>(path);
        Dictionary<SpaceshipColor, Sprite> sprites = new Dictionary<SpaceshipColor, Sprite>();

        if ( spritesOnPath != null)
        {
            for (int i = 0; i < spritesOnPath.Length; i++)
            {
                Sprite sprite = spritesOnPath[i];
                sprites.Add(GetSpriteColorEnumByName(sprite), sprite);
            }
        }
        return sprites;
    }

    private SpaceshipColor GetSpriteColorEnumByName(Sprite sprite)
    {
        if (sprite.name.Contains("_BLUE"))
        {
            return SpaceshipColor.Blue;
        }
        else if (sprite.name.Contains("_GREEN"))
        {
            return SpaceshipColor.Green;
        }
        else if (sprite.name.Contains("_NAVY BLUE"))
        {
            return SpaceshipColor.NavyBlue;
        }
        else if (sprite.name.Contains("_ORANGE"))
        {
            return SpaceshipColor.Orange;
        }
        else if (sprite.name.Contains("_PURPLE"))
        {
            return SpaceshipColor.Purple;
        }
        else if (sprite.name.Contains("_RED"))
        {
            return SpaceshipColor.Red;
        }
        else if (sprite.name.Contains("_YELLOW"))
        {
            return SpaceshipColor.Yellow;
        }
        else
        {
            Debug.LogError("found some sprite file named irregularly!");
            return SpaceshipColor.NONE;
        }
    }
}
