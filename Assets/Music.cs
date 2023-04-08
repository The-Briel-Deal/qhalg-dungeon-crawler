using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public AudioClip dungeon;
    public AudioClip boss;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayDungeon()
    {
        audio.Stop();
        audio.clip = dungeon;
        audio.Play();
    }

    public void PlayBoss()
    {
        audio.Stop();
        audio.clip = boss;
        audio.Play();
    }
}
