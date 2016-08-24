using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections;
using System.Text;
using System;


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

    //a graphical interface to test on
    [HideInInspector]
    public bool isSeen = false;

    private float elapsed = 0.0f;

    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;

    void Start()
    {    
        //get the component of audio source
        src = GetComponent<AudioSource>();
        samples = new float[sampleCount];   //an array of 256 sample points

        //Begin the microphone listening
        StartMicListener();
        StartKeywordRecognition();
    }
    private void StartKeywordRecognition()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
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
    //find out whether the words uttered is recognized
    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
    }
    //update once per frame
    void Update()
    {
        //restart the audio if it stopped playing
        if(!src.isPlaying)
        {
            StartMicListener();
        }

        //let the keyword recognizer start listening if it isn't
        if(!m_Recognizer.IsRunning)
        {
            StartKeywordRecognition();
        }

        //Determine if voice is loud enough
        voiceLoudEnough();        
        transform.position += new Vector3(0.0f, Mathf.Sin(Time.time) * 0.005f, 0.0f);
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
    bool voiceLoudEnough()
    {
        //determine the loudness of the sound with sensitivity factored in
        loudness = GetAverageVolume() * sensitivity;

        //if it exceeds the threshold defined
        if(loudness > threshold)
        {
            Debug.Log("Loudness: " + loudness);
            this.transform.FindChild("glow_card").gameObject.SetActive(true);
            return true;
        }
        //if it doesn't, then return false
        this.transform.FindChild("glow_card").gameObject.SetActive(false);
        return false;
    }
}