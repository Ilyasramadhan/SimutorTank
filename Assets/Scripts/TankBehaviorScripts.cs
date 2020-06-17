using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehaviorScripts : MonoBehaviour
{
    private Transform myTransform;
    private string stateRotasiVertikal;

    public float kecepatanRotasi = 20;
    public GameObject selongsong;
    public float nilaiRotasiY;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        #region Horizontal
        if (Input.GetKey(KeyCode.T))
        {
            myTransform.Rotate(Vector3.back * kecepatanRotasi * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.U))
        {
            myTransform.Rotate(Vector3.forward * kecepatanRotasi * Time.deltaTime, Space.Self);
        }
        #endregion

        #region State
        nilaiRotasiY = 360 - selongsong.transform.localEulerAngles.x;

        if (nilaiRotasiY == 0 || nilaiRotasiY == 360)
        {
            stateRotasiVertikal = "aman";
        }
        else if(nilaiRotasiY > 0 && nilaiRotasiY < 15)
        {
            stateRotasiVertikal = "aman";
        }
        else if (nilaiRotasiY > 15 && nilaiRotasiY <16)
        {
            stateRotasiVertikal = "atas";
        }
        else if (nilaiRotasiY > 350)
        {
            stateRotasiVertikal = "bawah";
        }

        #endregion

        #region Vertikal Berdasarkan State
        if( stateRotasiVertikal == "aman")
        {
            if(Input.GetKey(KeyCode.Y))
            {
                selongsong.transform.Rotate(Vector3.left * kecepatanRotasi * Time.deltaTime, Space.Self);
            }
            else if (Input.GetKey(KeyCode.H))
            {
                selongsong.transform.Rotate(Vector3.right * kecepatanRotasi * Time.deltaTime, Space.Self);
            }
        }
        else if (stateRotasiVertikal == "bawah")
        {
            selongsong.transform.localEulerAngles = new Vector3(
                -0.5f, selongsong.transform.localEulerAngles.y, selongsong.transform.localEulerAngles.z);
        }
        else if (stateRotasiVertikal == "atas")
        {
            selongsong.transform.localEulerAngles = new Vector3(
                -14.5f, selongsong.transform.localEulerAngles.y, selongsong.transform.localEulerAngles.z);
        }
        #endregion
    }
}
