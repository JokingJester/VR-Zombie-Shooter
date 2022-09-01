using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int bullets;

    [SerializeField]
    private Belt _belt;
    [SerializeField]
    private AudioClip _pickupAudio;
    [SerializeField]
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _belt = GameObject.Find("Clip Visual").GetComponent<Belt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _belt.AddClip(2);
            Destroy(this.gameObject, 1.0f);
            audioSource.PlayOneShot(_pickupAudio);
        }
    }
}
