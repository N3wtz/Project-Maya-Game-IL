using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventRelay : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public void RelayFootstep()
    {
        if (playerMovement != null)
        {
            playerMovement.PlaySound("footstep");
        }
    }
}
