using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBump : MonoBehaviour
{
    public float songBpm;

    public float secPerBeat;


    public static float songPosInBeats;

    public float songPosInSec;

    public float dspSongTime;

    //public float beatsInSong;

    public static AudioSource AS;

    public int beatmarker;

    public Transform bS1;
    public Transform bS2;

    float camSize;

    // Start is called before the first frame update
    void Start()
    {
        camSize = Camera.main.orthographicSize;
        //DontDestroyOnLoad(this.gameObject);
        AS = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;

        AS.Play();
    }
    bool offbeat = true;
    // Update is called once per frame
    void Update()
    {
        if (AS.isPlaying)
        {
            //determine how many seconds since the song started
            songPosInSec = (float)(AudioSettings.dspTime - dspSongTime);

            //determine how many beats since the song started
            songPosInBeats = songPosInSec / secPerBeat;
        }

        if (songPosInBeats >= beatmarker)
        {
            bS1.localScale = Vector3.one;
            bS2.localScale = Vector3.one;
            if (offbeat)
            {
                Camera.main.orthographicSize +=.3f;
            }
            offbeat = !offbeat;
            beatmarker++;
        }

        bS1.localScale = Vector3.Lerp(bS1.localScale,Vector3.one*1.3f,Time.deltaTime * 5);
        bS2.localScale = Vector3.Lerp(bS1.localScale,Vector3.one*1.3f,Time.deltaTime * 5);

        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize,camSize,Time.deltaTime * 2);
    }
}
