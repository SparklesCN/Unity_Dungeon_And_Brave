using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class C1P_FX : MonoBehaviour
{
    public bool lookAtCamera = false;
    public GameObject theCamera;

	public List<string> nameColorAtt = new List<string>();
	public List<Vector2> colorRangeAtt = new List<Vector2>();
	
	// Update is called once per frame	
	void Start ()
	{
        if (theCamera == null)
            theCamera = GameObject.Find("Main Camera");

		GetComponent<PKFxFX>().StopEffect();
        isLookAtCamera();
		randomColor();
		GetComponent<PKFxFX>().StartEffect();
	}

    public void isLookAtCamera()
    {
        if (lookAtCamera) {
            transform.LookAt(theCamera.transform);
            transform.Rotate(Vector3.up, 180f);
        }
    }
	
	public void randomColor()
	{
        if (nameColorAtt != null && colorRangeAtt != null)
            if (nameColorAtt.Count == colorRangeAtt.Count)
                for (int i=0 ; i<colorRangeAtt.Count ; i++) {
                    Vector3 v = new Vector3 (Random.Range(colorRangeAtt[i].x, colorRangeAtt[i].y),Random.Range(colorRangeAtt[i].x, colorRangeAtt[i].y),Random.Range(colorRangeAtt[i].x, colorRangeAtt[i].y));
                    GetComponent<PKFxFX>().SetAttribute(new PKFxManager.Attribute(nameColorAtt[i], v));
			    }
	}
}
