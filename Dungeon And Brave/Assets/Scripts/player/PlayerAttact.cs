using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttact : MonoBehaviour
{
    public GameObject attact;
    public Transform spellPos;
    float myTime = 0f;
    float nextFire = 0.5f;
    public float attactGap = 1f;

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire){
            nextFire += attactGap;
            //Instantiate(Object original, Vector3 position, Quaternion rotation)
            GameObject copy_attact = Instantiate(attact, spellPos.position, spellPos.rotation) as GameObject;


        }
    }
}
