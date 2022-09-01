using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Belt : MonoBehaviour
{
    public float pistolClips = 2;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _gunClipPrefab;
    [SerializeField] private GameObject _gunClipVisual;
    [SerializeField] private MeshRenderer _clipVisualRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _text.text = pistolClips.ToString() + "X";
        for (int i = 0; i < pistolClips; i++)
        {
            GameObject newClip = Instantiate(_gunClipPrefab, _gunClipVisual.transform.position, _gunClipVisual.transform.rotation);
            newClip.transform.parent = _gunClipVisual.transform;
        }
    }

    public void RemoveClip()
    {
        pistolClips--;
        _text.text = pistolClips.ToString() + "X";
        if (pistolClips == 0)
            _clipVisualRenderer.enabled = false;
    }
    public void AddClip(int clips)
    {
        if(clips > 1)
        {
            for (int i = 0; i < clips; i++)
            {
                GameObject newClip = Instantiate(_gunClipPrefab, _gunClipVisual.transform.position, _gunClipVisual.transform.rotation);
                newClip.transform.parent = _gunClipVisual.transform;
            }
        }
        _clipVisualRenderer.enabled = true;
        pistolClips = pistolClips + clips;
        _text.text = pistolClips.ToString() + "X";
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Clip")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            GunClip clip = other.GetComponent<GunClip>();
            if(rb != null && clip != null)
            {
                rb.isKinematic = true;
                other.transform.position = _gunClipVisual.transform.position;
                other.transform.rotation = _gunClipVisual.transform.rotation;
                clip.grabbed = false;
                AddClip(1);
            }
        }
    }
}
