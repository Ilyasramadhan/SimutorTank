using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrakPeluruScripts : MonoBehaviour
{
    private Transform myTransform;
    public float waktuTerbangPeluru;
    private TankBehaviorScripts tankBehavior;
    private float _kecAwal;
    private float _sudutTembak;
    private float _sudutMeriam;
    private float _gravitasi;
    private Vector3 _posisiAwal;
    private AudioSource audioSource;

    public GameObject ledakan;
    public AudioClip audioLedakan;

    private GameManagerScripts gameManager;
    private bool isLanded = true;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;

        tankBehavior = GameObject.Find("Torque").GetComponent<TankBehaviorScripts>();
        tankBehavior = GameObject.FindObjectOfType<TankBehaviorScripts>();
        _kecAwal = tankBehavior.kecepatanAwalPeluru;
        _sudutTembak = tankBehavior.nilaiRotasiY;
        _sudutMeriam = tankBehavior.sudutMeriam;

        _posisiAwal = myTransform.position;

        audioSource = GetComponent<AudioSource>();

        _gravitasi = GameObject.FindObjectOfType<TankBehaviorScripts>().gravity;

        gameManager = GameObject.FindObjectOfType<GameManagerScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        //waktuTerbangPeluru = waktuTerbangPeluru + Time.deltaTime;
        if(isLanded)
        waktuTerbangPeluru += Time.deltaTime;

        gameManager._lamaWaktuTerbangPeluru = this.waktuTerbangPeluru;

        myTransform.position = PosisiTerbangPeluru(_posisiAwal, _kecAwal, waktuTerbangPeluru, _sudutTembak, _sudutMeriam);
    }

    private Vector3 PosisiTerbangPeluru(Vector3 _posisiAwal, float _kecAwal, float _waktu,
        float _sudutTembak, float _sudutMeriam)
    {
        float _x = _posisiAwal.x + (_kecAwal * _waktu * Mathf.Sin(_sudutMeriam * Mathf.PI / 180));
        float _y = _posisiAwal.y + ((_kecAwal * _waktu * Mathf.Sin(_sudutTembak * Mathf.PI / 180))-(0.5f * _gravitasi * Mathf.Pow(_waktu, 2)));
        float _z = _posisiAwal.z + (_kecAwal * _waktu * Mathf.Cos(_sudutMeriam * Mathf.PI / 180));

        return new Vector3(_x, _y, _z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Land")
        {
            GameObject go = Instantiate(ledakan, myTransform.position, Quaternion.identity);
            Destroy(go, 3f);

            audioSource.PlayOneShot(audioLedakan);

            Destroy(this.gameObject, 3f);

            gameManager._jarakTembak = Vector3.Distance(_posisiAwal, myTransform.position);

            isLanded = false;
        }
    }
}
