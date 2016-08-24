using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Microphone_Input : MonoBehaviour
{
    private static int frequency = 44100;   //frequency of sound
    private static int sampleCount = 256;   //time samples

    private float[] samples;                //the array of samples

    AudioSource src;                        //the audio source of the microphone
    float threshold = 1.5f;                 //threshold required to exceed in order to begin voice recognition
    float loudness = 0.0f;                  //loudness of microphone input
    public float sensitivity = 100.0f;      //the sensitivity of the microphone

    public bool volumeLoud = false;         //debugging for loudness check

    public KeywordRecognition keyword;      //keyword object

    void Start()
    {
        //get the component of audio source
        src = GetComponent<AudioSource>();
        samples = new float[sampleCount];   //an array of 256 sample points

        //Begin the microphone listening
        StartMicListener();
    }
    
    //starts the microphone recording
    private void StartMicListener()
    {
        src.clip = Microphone.Start(null, true, 10, frequency);

        //waits for microphone input
        while(!(Microphone.GetPosition(null) > 0))
        {
            src.Play();
            //src.mute = true;    //No, it doesn't work when you do this
        }
    }

    void Update()
    {
        //restart the audio if it stopped playing
        if(!src.isPlaying)
        {
            StartMicListener();
        }

        //Determine if voice is loud enough
        voiceLoudEnough();
    }

    //analyze the sound samples
    float GetAverageVolume()
    {
        //the summation of numbers
        float sum = 0.0f;

        //get the block of output of sound data
        src.GetOutputData(samples, 0);

        for (int i = 0; i < sampleCount; i++)
        {
            //calculate the total absolute values to of the points in the graph given
            sum += Mathf.Abs(samples[i]);
        }

        //return the average value to determine its volume
        return sum / sampleCount;
    }

    //determine the loudness of the sound
    //return true if it exceeds the threshold
    bool voiceLoudEnough()
    {
        //determine the loudness of the sound with sensitivity factored in
        loudness = GetAverageVolume() * sensitivity;

        //if it exceeds the threshold defined
        if(loudness > threshold)
        {
            //Debug.Log("Loudness: " + loudness);
            return true;
        }
        //if it doesn't, then return false
        return false;
    }
}