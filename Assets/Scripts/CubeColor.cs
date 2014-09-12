using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeColor : MonoBehaviour {
    
    private const int num_cubesample = 3;
    private const int num_cube = 3;
    private const int num_color = 6;

    private GameObject[] cubeSamples = new GameObject[num_cubesample];
    private GameObject[] cubes = new GameObject[num_cube];

    private Color[] colorMap = new Color[num_color]{Color.red, Color.green, Color.blue, Color.yellow, Color.magenta, Color.cyan};

    private bool isMatched = false;

    private GameObject particleSystem;
	// Use this for initialization
	void Start () {
        cubeSamples[0] = GameObject.Find("CubeSample01");
        cubeSamples[1] = GameObject.Find("CubeSample02");
        cubeSamples[2] = GameObject.Find("CubeSample03");

        cubes[0] = GameObject.Find("Cube01");
        cubes[1] = GameObject.Find("Cube02");
        cubes[2] = GameObject.Find("Cube03");
        particleSystem = GameObject.Find("ParticleSystem");
        RandomColor(cubeSamples, colorMap);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            RandomColor(cubeSamples, colorMap);
        if (Input.GetKeyDown(KeyCode.Return))
            RandomColor(cubes, colorMap);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            particleSystem.particleSystem.Play();
        if (CheckCubeMatchStatus())
        {
            particleSystem.particleSystem.Play();
            Debug.Log("GREAT!!!!");
            RandomColor(cubeSamples, colorMap);
            
        }
	}

    bool CheckCubeMatchStatus()
    { 
        for(int i = 0; i < 3; i++)
        { 
            if(cubes[i].renderer.material.color != cubeSamples[i].renderer.material.color)
                return false;
        }
        return true;
    }

    void RandomColor(GameObject[] cube, Color[] color)
    {
        int num_cube = cube.Length;
        int num_color = color.Length;

        for (int i = 0; i < num_cube; i++)
        {
            int colorIndex = Random.Range(0, num_color);
            cube[i].renderer.material.color = colorMap[colorIndex];
        }
    }
}
