using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class C1P_PointClickSpawn : MonoBehaviour
{	
	public float rotateSpeed = 10;
	private float tempRotateSpeed;
	
	public int maxPlayableFx = 5;

	public List<GameObject>	m_FX;
	public Texture 			tex;
	public Texture 			tex2;
	public Texture 			tex3;

	private int				m_CurrentFx = 0;
	private List<GameObject> listMaxFX = new List<GameObject>();

	void Awake()
	{
		Cursor.visible = true;

		tempRotateSpeed = rotateSpeed;

		// The number of FX can't be < 0
		if (maxPlayableFx <= 0)
			maxPlayableFx = 1;
	}

	void OnGUI()
	{
		// HUD : Arrows : L R
		if (tex != null) {
			GUI.DrawTexture (new Rect (10, 0, tex.width/2.0f, tex.height/2.0f), tex);
			GUI.Label (new Rect (120, 0+50, tex.width, tex.height/2.0f), "Switch Fx");
		}
		// HUD : Stop Camera
		if (tex2 != null) {
			GUI.DrawTexture(new Rect(10, 50, tex2.width/2.0f, tex2.height/2.0f), tex2);
			GUI.Label (new Rect (120, 50+50, tex2.width, tex2.height/2.0f), "Stop the Camera");
		}
		// HUD : Mouse Click
		if (tex3 != null) {
			GUI.DrawTexture(new Rect(15, 120, tex3.width/2.0f, tex3.height/2.0f), tex3);
			GUI.Label (new Rect (120, 120+50, tex3.width, tex3.height/2.0f), "Play the Fx");
		}

		// HUD : FX Name
		GUI.Label(new Rect(Screen.width-400, 50, 400, 400), "<size=30>FX : "+(m_CurrentFx+1)+" / "+m_FX.Count+"\nName : "+m_FX[m_CurrentFx].name+"</size>");
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			StopAllFx();
			m_CurrentFx = (m_CurrentFx + 1) % m_FX.Count;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			StopAllFx();
			m_CurrentFx = (m_CurrentFx - 1) % m_FX.Count;
			if (m_CurrentFx < 0)
				m_CurrentFx = m_FX.Count + m_CurrentFx;
		}

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();
            if (Physics.Raycast(ray, out hit, 500))
            {
                Vector3 hitPos = hit.point + hit.normal.normalized / 10.0f;

                if (m_FX[m_CurrentFx].name == "Laser") { // Laser Exception
                    Vector3 origin = hitPos + Vector3.up * m_FX[m_CurrentFx].transform.position.y;
                    Vector3 target = hitPos + new Vector3(1,-1,1) * m_FX[m_CurrentFx].transform.position.y;

                    m_FX[m_CurrentFx].GetComponent<PKFxFX>().SetAttribute(new PKFxManager.Attribute("OriginPoint", origin));
                    m_FX[m_CurrentFx].GetComponent<PKFxFX>().SetAttribute(new PKFxManager.Attribute("Target", target));
                }
               
                if (m_FX[m_CurrentFx].name != "Laser" || hit.normal.normalized.y == 1) { // Laser can only spawn if this is a floor
                    GameObject prefab = m_FX [m_CurrentFx];
                    GameObject go = Instantiate(prefab, hitPos, prefab.transform.rotation) as GameObject;
				    go.transform.Rotate (Quaternion.FromToRotation (Vector3.up, hit.normal).eulerAngles);
				    go.transform.Translate (prefab.transform.position);	         

                    listMaxFX.Add(go);
				    listMaxFX[listMaxFX.Count-1].GetComponent<PKFxFX>().StopEffect();
				    listMaxFX[listMaxFX.Count-1].GetComponent<PKFxFX>().StartEffect();

				    if (listMaxFX.Count > maxPlayableFx) {					
					    if (listMaxFX[0] != null) {
						    listMaxFX[0].GetComponent<PKFxFX>().StopEffect();
						    Destroy(listMaxFX[0]);
						    listMaxFX.RemoveAt(0);
					    }
				    }
                }
			}
		}

		// STOP CAMERA
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (tempRotateSpeed > 0)
				tempRotateSpeed = 0;
			else
				tempRotateSpeed = rotateSpeed;
		}
		
		// Rotation of the Camera
		transform.Rotate(Vector3.up * Time.deltaTime * tempRotateSpeed, Space.World);
	}

	void StopAllFx()
	{
		foreach (GameObject fx in listMaxFX) {
			if (fx != null) {
				fx.GetComponent<PKFxFX>().StopEffect();
				Destroy(fx);
			}
		}
		listMaxFX.Clear();
	}
}
