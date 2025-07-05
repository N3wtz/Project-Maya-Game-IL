using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineEndDialogueTrigger : MonoBehaviour
{
    public PlayableDirector director;
    public DialogueSO dialogueToStart;

    private void OnEnable()
    {
        if (director != null)
        {
            director.stopped += OnTimelineFinished;
        }
    }

    private void OnDisable()
    {
        if (director != null)
        {
            director.stopped -= OnTimelineFinished;
        }
    }

    private void OnTimelineFinished(PlayableDirector pd)
    {
        if (pd == director && dialogueToStart != null)
        {
            DialogueManager.Instance.StartDialogue(dialogueToStart);
        }
    }
}
