using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;
    [SerializeField] private float handleRange = 1f;

    public Vector2 Input{get; private set;}

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        bool success = RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out localPoint);

        if(!success)
            return;

        Vector2 halfSize = background.rect.size / 2f;
        Vector2 normalizedInput = new Vector2(localPoint.x / halfSize.x, localPoint.y / halfSize.y);

        Input = Vector2.ClampMagnitude(normalizedInput, 1f);

        handle.anchoredPosition = Input * (halfSize.x * handleRange);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
