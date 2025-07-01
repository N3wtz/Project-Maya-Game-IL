using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneTransition : MonoBehaviour
{
    public string sceneToLoad; // Nama scene yang akan dimuat setelah video selesai
    private VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer tidak ditemukan!");
            return;
        }

        // Subscribe ke event saat video selesai
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // Update is called once per frame
    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
