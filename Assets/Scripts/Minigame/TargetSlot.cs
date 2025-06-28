using UnityEngine;

public class TargetSlot : MonoBehaviour
{
    public int slotID;
    private DraggablePiece currentPiece;

    public bool IsEmpty()
    {
        return currentPiece == null;
    }

    public void SetPiece(DraggablePiece piece)
    {
        currentPiece = piece;
    }

    public void RemovePiece()
    {
        currentPiece = null;
    }

    public bool IsCorrect()
    {
        return currentPiece != null && currentPiece.pieceID == slotID;
    }
}
