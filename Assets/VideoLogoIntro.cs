//============================================================//
//                         Video Intro                        //
//============================================================//
//                  Created: 2018-01-31 11:59 pm              //
//                  Updated: 2017-XX-XX                       //
//                  Version 1.0.0                             //
//                  Revisions 0                               //
//============================================================//
// Author: Jonathan Thompson                                  //  
// Contact: @programmerJon | Mr.j.thompson@hotmail.ca         //
//============================================================//
// Used to play my video logo intro.                          //
//============================================================//
//                   Resvision notes:                         //
//                                                            //
//                                                            //
//============================================================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoLogoIntro : MonoBehaviour {
    public enum ScreenLayout
	{
		LANDSCAPE,
		PORTRAIT
	};
    [Header("Video Clips To Play")]
    public VideoClip Clip01;
    [Header("Video Clip Properties")]
    public ScreenLayout currentLayout = ScreenLayout.LANDSCAPE;
    public int playSpeed;
    public VideoPlayer introClipPlayer;
	void Awake(){

        switch(currentLayout){
            case ScreenLayout.LANDSCAPE:
                Screen.orientation = ScreenOrientation.Landscape;
                break;

            case ScreenLayout.PORTRAIT:
                Screen.orientation = ScreenOrientation.Portrait;
                break;

            default:
                Screen.orientation = ScreenOrientation.Landscape;
                break;
        }

		
			// Will attach a VideoPlayer to the main camera.
			GameObject camera = GameObject.Find("Main Camera");

			// VideoPlayer automatically targets the camera backplane when it is added
			// to a camera object, no need to change videoPlayer.targetCamera.
			//var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

			// Play on awake defaults to true. Set it to false to avoid the url set
			// below to auto-start playback since we're in Start().
			//videoPlayer.playOnAwake = false;

			// By default, VideoPlayers added to a camera will use the far plane.
			// Let's target the near plane instead.
			//videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

			// This will cause our scene to be visible through the video being played.
			//videoPlayer.targetCameraAlpha = 0.5F;

			// Set the video to play. URL supports local absolute or relative paths.
			// Here, using absolute.
			//videoPlayer.url = "/Users/graham/movie.mov";
            //videoPlayer.clip = Clip01;

			// Skip the first 100 frames.
			//videoPlayer.frame = 100;

		// Restart from beginning when done.
		//videoPlayer.isLooping = false;

		// Each time we reach the end, we slow down the playback by a factor of 10.
		introClipPlayer.loopPointReached += EndReached;
		if(introClipPlayer.isPlaying) {
            EndReached(introClipPlayer);
        }

			// Start playback. This means the VideoPlayer may have to prepare (reserve
			// resources, pre-load a few frames, etc.). To better control the delays
			// associated with this preparation one can use videoPlayer.Prepare() along with
			// its prepareCompleted event.
			introClipPlayer.Play();
		
	}


    void EndReached(VideoPlayer vp){
		Debug.Log("Ended");
        SceneManager.LoadScene("TitleMenu");
	}
}
