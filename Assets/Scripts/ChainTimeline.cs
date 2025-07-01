using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ChainTimeline : MonoBehaviour
{
    public PlayableDirector firstTimeline;
    public PlayableDirector secondTimeline;
    public PlayableDirector thirdTimeline;

    void Start()
    {
        if (firstTimeline == null || secondTimeline == null || thirdTimeline == null)
        {
            Debug.LogError("Salah satu dari PlayableDirector belum di-assign!");
            return;
        }

        firstTimeline.stopped += OnFirstTimelineEnded;
        secondTimeline.stopped += OnSecondTimelineEnded;

        firstTimeline.Play();
    }

    void OnFirstTimelineEnded(PlayableDirector director)
    {
        if (director == firstTimeline)
        {
            secondTimeline.Play();
        }
    }

    void OnSecondTimelineEnded(PlayableDirector director)
    {
        if (director == secondTimeline)
        {
            thirdTimeline.Play();
        }
    }
}
