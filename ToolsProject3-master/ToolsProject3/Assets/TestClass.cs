using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass : MonoBehaviour {

    [ColorLine(0, 1, 1)]
    public int randomInt;

    [ColorLine(1,1,0)]
    [VectorScale(0, 25)]
    public Vector3 randomVector3;

    [ColorLine(1,0,1)]
    [SpriteShow(10)]
    public Sprite randomSprite;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
