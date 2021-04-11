using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiPlayerHud : MonoBehaviour
{
    [SerializeField]
    private Transform _playerLivesImagesParent;
    [SerializeField]
    private TMP_Text _playerScoreText;
    private int _playerScore;
    private Stack<GameObject> _playerLivesImages = new Stack<GameObject>();
    private WaitForSeconds _waitHalfSecond = new WaitForSeconds(0.5f);
    
    public void InstantiatePlayerSpaceshipImagesAndSetTheirSprites(SpaceshipType type, SpaceshipColor color, int numberOfLives)
    {
        Sprite sprite = Managers.Instance.ResourcesManager.GetSpriteBySpaceshipTypeAndColor(type, color);

        for (int i = 0; i < numberOfLives; i++)
        {
            GameObject image = new GameObject();
            image.transform.SetParent(_playerLivesImagesParent);
            Image imageComponent = image.AddComponent(typeof(Image)) as Image;
            imageComponent.sprite = sprite;
            _playerLivesImages.Push(image);
        }
    }

    public void SetPlayerScore(int score)
    {
        bool scoreGained = score - _playerScore >= 0;
        Color newColor = scoreGained ? Color.green: Color.red;
        _playerScore = score;
        _playerScoreText.text = _playerScore.ToString();
        ChangePlayerScoreTextColor(newColor);
    }

    public void DecreasePlayerLife()
    {
        if (_playerLivesImages.Count > 0)
        {
            GameObject poppedGameobject = _playerLivesImages.Pop();
            poppedGameobject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        Managers.Instance.PlayerScoreManager.OnScoreChanged += SetPlayerScore;
    }

    private void ChangePlayerScoreTextColor(Color color)
    {
        _playerScoreText.color = color;
        StartCoroutine(ResetColorToDefault());
    }

    private IEnumerator ResetColorToDefault()
    {
        yield return _waitHalfSecond;
        _playerScoreText.color = Color.white;
    }
}
