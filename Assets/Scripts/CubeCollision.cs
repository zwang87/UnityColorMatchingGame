using UnityEngine;
using System.Collections;

public class CubeCollision : MonoBehaviour {
    private Color[] colorMap = new Color[] { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta, Color.cyan };
    public Material alterMat;
    public int count = 0;
    private Material originMat;

    private float lastTime = 0;
    private float currentTime = 0;

	// Use this for initialization
	void Start () {
        originMat = transform.renderer.material;
	}

    bool isColliding = false;
    bool isExited = true;
	// Update is called once per frame
	void Update () {
        isColliding = false;
	}

    void OnCollisionEnter(Collision other)
    {
        if (isColliding || !isExited) return;
        isColliding = true;
        isExited = false;
        currentTime = Time.realtimeSinceStartup;

        float time = currentTime - lastTime;

        Debug.Log(time);

        if (time >= 0.3)
        {
            transform.renderer.material.color = colorMap[count % colorMap.Length];
            count++;
        }
        lastTime = currentTime;
    }

    void OnCollisionExit(Collision other)
    {
        isExited = true;
    }
}
