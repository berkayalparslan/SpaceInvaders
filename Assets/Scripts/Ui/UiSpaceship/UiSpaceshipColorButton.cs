using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiSpaceshipColorButton : MonoBehaviour
{
    public event UnityAction<SpaceshipColor> OnButtonClick;
    [SerializeField]
    private SpaceshipColor _color;
    private Button _button;
    private Image _image;

    public SpaceshipColor Color
    {
        get
        {
            return _color;
        }
    }


    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();

        _button.onClick.AddListener(OnClick);
        _image.color = UiColorHelper.GetColor(_color);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OnClick()
    {
        if (OnButtonClick != null)
        {
            OnButtonClick(_color);
        }
    }
}
