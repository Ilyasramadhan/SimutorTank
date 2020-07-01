using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScripts : MonoBehaviour
{
    public GameObject go_sudutMeriam;
    public GameObject go_sudutTembak;
    public GameObject go_kecepatanAwal;
    public GameObject go_gravitasi;
    public GameObject go_jarak;
    public GameObject go_waktuTerbangPeluru;

    public GameObject _torque;
    public GameObject _selongsong;

    public float _lamaWaktuTerbangPeluru;
    public float _jarakTembak;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        go_sudutMeriam.GetComponent<Text>().text =
            _torque.GetComponent<TankBehaviorScripts>().sudutMeriam.ToString();

        go_sudutTembak.GetComponent<Text>().text =
            _torque.GetComponent<TankBehaviorScripts>().nilaiRotasiY.ToString();

        go_gravitasi.GetComponent<Text>().text =
            _torque.GetComponent<TankBehaviorScripts>().gravity.ToString();

        go_kecepatanAwal.GetComponent<Text>().text =
            _torque.GetComponent<TankBehaviorScripts>().kecepatanAwalPeluru.ToString();

        go_waktuTerbangPeluru.GetComponent<Text>().text = _lamaWaktuTerbangPeluru.ToString();

        go_jarak.GetComponent<Text>().text = _jarakTembak.ToString();
    }
}
