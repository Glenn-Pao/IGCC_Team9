using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;
using System;
using System.Text;

//this class is constructed based on the sample code provided by Unity 5.4 documentaton
//the actual code might turn out to be a little different.

//WARNING: THIS SCRIPT WORKS ONLY ON WINDOWS 10

//Authored by Almeda Glenn
public class KeywordRecognition : MonoBehaviour 
{

    [SerializeField] 
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;

	// Use this for initialization
	void Start () 
    {
        //initialize the keywords
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
	}
    
    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0}{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
    }
}
