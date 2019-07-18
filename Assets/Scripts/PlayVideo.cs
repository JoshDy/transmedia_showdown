using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour {

    public RawImage image;
    public VideoClip videoToPlay;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
	}

    IEnumerator playVideo()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        videoPlayer.source = VideoSource.VideoClip;

        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        videoPlayer.EnableAudioTrack(0, true);

        videoPlayer.clip = videoToPlay;

        videoPlayer.Prepare();

        WaitForSeconds waitTime = new WaitForSeconds(0);
        while (!videoPlayer.isPrepared)
        {
            yield return waitTime;
        }

        videoPlayer.isLooping = true;

        image.texture = videoPlayer.texture;

        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float) videoPlayer.time));
            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
