using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour {

    public RawImage image;
    public VideoClip videoToPlay;
    public VideoClip videoToPlay2;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;
    private VideoSource videoSource2;

	// Use this for initialization
	void Start () {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
	}

    IEnumerator playVideo()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        WaitForSeconds waitTime = new WaitForSeconds(0);
        while (!videoPlayer.isPrepared)
        {
            yield return waitTime;
        }

        videoPlayer.isLooping = false;

        image.texture = videoPlayer.texture;

        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        WaitForSeconds waitFor = new WaitForSeconds(2);

        videoPlayer.clip = videoToPlay2;
        videoPlayer.Prepare();

        WaitForSeconds waitTime2 = new WaitForSeconds(0);
        while (!videoPlayer.isPrepared)
        {
            yield return waitTime2;
        }

        videoPlayer.isLooping = true;

        image.texture = videoPlayer.texture;

        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
