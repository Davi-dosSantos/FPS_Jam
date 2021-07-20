using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnTrigger : MonoBehaviour
{
    public float tempoDoAudio = 0f;
    public GameObject player;
    public AudioSource Audio;
    void Start()
    {
        Audio.playOnAwake = false;
        Audio.loop = false;
    }
    
    void Update()
    {   if(player)
        if (Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            Audio.Play();
            Destroy(Audio, tempoDoAudio);
        }
            
    }
}
