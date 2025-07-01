using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int pieceID;
    private Vector2 originalPosition;
    private Transform originalParent;
    private CanvasGroup canvasGroup;

    public TargetSlot currentSlot; // Slot tempat piece ini berada

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        GameObject target = eventData.pointerCurrentRaycast.gameObject;
        TargetSlot slot = target != null ? target.GetComponent<TargetSlot>() : null;

        // Jika sebelumnya ada slot, kosongkan dulu
        if (currentSlot != null)
        {
            currentSlot.RemovePiece();
            currentSlot = null;
        }

        if (slot != null && slot.IsEmpty())
        {
            // Masuk ke slot baru
            transform.SetParent(slot.transform);
            transform.localPosition = Vector3.zero;
            slot.SetPiece(this);
            currentSlot = slot;
        }
        else
        {
            // Tetap di posisi drop, bukan slot
            transform.SetParent(originalParent.root); // misal Canvas
        }

        PuzzleManager manager = FindObjectOfType<PuzzleManager>();
        if (manager != null)
        {
            manager.CheckWin();
        }
    }
}
