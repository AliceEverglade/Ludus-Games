using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] private MusicStateSO musicState;
    public AudioSource source1;
    public AudioSource source2;
    public AudioSource source3;
    public AudioSource source4;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;


    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Fight":
                musicState.inBattle = true;
                musicState.ending = false;
                musicState.bgmus = false;
                musicState.titlemus = false;
                break;

            case "Map":
                musicState.inBattle = false;
                musicState.ending = false;
                musicState.bgmus = true;
                musicState.titlemus = false;
                break;

            case "TitleScreen":
                musicState.inBattle = false;
                musicState.ending = false;
                musicState.bgmus = false;
                musicState.titlemus = true;
                break;

            case "Credits":
                musicState.inBattle = false;
                musicState.ending = true;
                musicState.bgmus = false;
                musicState.titlemus = false;
                break;

        }
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

        if (musicState.titlemus == true && !source4.isPlaying)
        {
            source4.PlayOneShot(clip4);
            source4.PlayScheduled(AudioSettings.dspTime + clip4.length);
        }
        if (musicState.titlemus == false)
        {
            source4.Stop();
        }
    }
}

