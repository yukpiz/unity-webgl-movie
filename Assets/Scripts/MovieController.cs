using UnityEngine;
using System.Collections;

public class MovieController : MonoBehaviour {

    public GameObject cube;
    private WebGLMovieTexture webGLMovieTexture;

	// Use this for initialization
	void Start () {
        webGLMovieTexture = new WebGLMovieTexture("StreamingAssets/Chrome_ImF.mp4");
        cube.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
        cube.GetComponent<MeshRenderer>().material.mainTexture = webGLMovieTexture;
        webGLMovieTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (webGLMovieTexture.isReady)
        {
            webGLMovieTexture.Update();
        }
	}

    public void Play()
    {
        StartCoroutine("StartMovie", false);
    }

    public void Stop()
    {
        if (webGLMovieTexture.isReady)
        {
            webGLMovieTexture.Pause();
            webGLMovieTexture.Seek(0f);
        }
    }

    public void Pause()
    {
        if (webGLMovieTexture.isReady)
        {
            webGLMovieTexture.Pause();
        }
    }

    protected IEnumerator StartMovie(bool isLoop)
    {
        while (!webGLMovieTexture.isReady)
        {
            yield return null;
        }

        webGLMovieTexture.loop = isLoop;
        webGLMovieTexture.Play();
    }
}
