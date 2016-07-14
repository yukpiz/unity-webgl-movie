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
	}
	
	// Update is called once per frame
	void Update () {
        if (webGLMovieTexture.isReady)
        {
            webGLMovieTexture.Update();
        }
	}
}
