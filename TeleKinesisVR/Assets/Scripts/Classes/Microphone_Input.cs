using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Microphone_Input : MonoBehaviour
{
    AudioSource src;

    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            src.clip = Microphone.Start(null, true, 10, 44100);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Microphone.End(null);
            src.Play(); // Play the audio source!
        }
    }
}