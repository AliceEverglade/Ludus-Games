using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] private MusicStateSO musicState;
    public AudioSource source1;
    public AudioSource source2;
    public AudioSource source3;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (musicState.inBattle == true && !source1.isPlaying)
        {
            source1.PlayOneShot(clip1);
           source1.PlayScheduled(AudioSettings.dspTime + clip1.length);
        }
        if (musicState.inBattle == false)
        {
            source1.Stop();
        }

        if (musicState.ending == true && !source2.isPlaying)
        {
            source2.PlayOneShot(clip2);
            source2.PlayScheduled(AudioSettings.dspTime + clip2.length);
        }
        if (musicState.ending == false)
        {
            source2.Stop();
        }

        if (musicState.bgmus == true && !source3.isPlaying)
        {
            source3.PlayOneShot(clip3);
            source3.PlayScheduled(AudioSettings.dspTime + clip3.length);
        }
        if (musicState.bgmus == false)
        {
            source3.Stop();
        }
    }
}
