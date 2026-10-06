using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) => OnClick();
    protected abstract void OnClick();
}
