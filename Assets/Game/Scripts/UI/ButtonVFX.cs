using System;
using UnityEngine;
using UnityEngine.EventSystems;
using PrimeTween;
using UnityEngine.UI;

public class ButtonVFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private float ButtonMaxSize => 1.15f;
    private float ButtonMinSize => 0.9f;
    private float ButtonSizeTime => 0.1f;
    private Tween sizeTween;
    public void OnPointerEnter(PointerEventData eventData) => OnEnter();
    public void OnPointerExit(PointerEventData eventData) => OnExit();
    public void OnPointerDown(PointerEventData eventData) => OnDown();
    public void OnPointerUp(PointerEventData eventData) => OnUp();

    private void OnEnter() => ChangeButtonSize(ButtonMaxSize);

    private void OnExit() => SizeReset();

    private void OnDown() => ChangeButtonSize(ButtonMinSize);

    private void OnUp() => SizeReset();

    private void ChangeButtonSize(float size = 1)
    {
        if (transform.localScale == new Vector3(size, size, size)) return;

        sizeTween = Tween.Scale(transform, size, ButtonSizeTime, ease: Ease.OutBack);
    }

    private void SizeReset()
    {
        if (sizeTween.isAlive)
            sizeTween.Stop();

        ChangeButtonSize();
    }
}
