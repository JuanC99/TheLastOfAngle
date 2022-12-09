using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVideoController : MonoBehaviour
{

    public GameObject uiMenu;
    public GameObject terreno;
    private UnityEngine.Video.VideoPlayer videoPlayer;
    public Material skyboxVideo;
    public Material skyboxNormal;


    void Start()
    {
        videoPlayer = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        uiMenu.SetActive(true);
        terreno.SetActive(true);
        RenderSettings.skybox = skyboxNormal;
        this.gameObject.SetActive(false);
    }

    public void InitVideo()
    {
        uiMenu.SetActive(false);
        terreno.SetActive(false);
        RenderSettings.skybox = skyboxVideo;
    }
}
