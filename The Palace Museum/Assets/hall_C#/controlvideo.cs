using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class controlvideo : MonoBehaviour {
    private VideoPlayer videoPlayer;
    public GameObject text;
	// Use this for initialization
	void Start () {
        videoPlayer = this.GetComponent<VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)&&(text.activeSelf==true))
        {
            PlayOrPauseVideo();
        }
	}
    private void PlayOrPauseVideo()
    {
        if (videoPlayer.isPlaying == true)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    
    }
    void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }

}
