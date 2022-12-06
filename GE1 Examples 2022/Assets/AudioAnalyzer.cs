using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer : MonoBehaviour {

    public bool useMic = false;
    public AudioClip clip;
    AudioSource a;
    public AudioMixerGroup amgMic;
    public AudioMixerGroup amgMaster;

    public string selectedDevice;

    public static int frameSize = 512;
    public float[] spectrum;
    public float[] samples;

    public float[] bands;

    public float binWidth;
    public float sampleRate;

    public static AudioAnalyzer Instance;

    /*
     * 20-60 - Subbase
     * 60-250 - Bass
     * 250-500 - Low midrange
     * 500 - 2Khz - Midrange
     * 2Khz - 4Khz - Upper midrange
     * 4Khz - 6Khz - Presence
     * 6Khz - 20Khz - Brilliance
     */

    private void Awake()
    {
        StartCoroutine(Awake1());
    }

    IEnumerator Awake1()
    {
        Instance = this;
        a = GetComponent<AudioSource>();
        spectrum = new float[frameSize];
        samples = new float[frameSize];
        bands = new float[(int) Mathf.Log(frameSize, 2)];
        
        if (useMic)
        {
            foreach(string s in Microphone.devices)
            {
                Debug.Log(s);
            }
            if (Microphone.devices.Length > 0)
            {   
                selectedDevice = Microphone.devices[0].ToString();
                Debug.Log("Setting device to: " + selectedDevice);
                a.clip = Microphone.Start(selectedDevice, true, 1, AudioSettings.outputSampleRate);
                //a.outputAudioMixerGroup = amgMic;
            }
        }
        else
        {
            a.clip = clip;
            a.outputAudioMixerGroup = amgMaster;
        }

        while(Microphone.GetPosition(selectedDevice) == 0)
        {
            Debug.Log("Yielding");
            yield return null;
        }
        Debug.Log("Playing");
        a.Play();       
    }

    // Use this for initialization
    void Start () {        
        sampleRate = AudioSettings.outputSampleRate;
        binWidth = AudioSettings.outputSampleRate / 2 / frameSize;

        fSample = AudioSettings.outputSampleRate;
    }

    /*
     * This is the method from the youtube video tutorial. 
     * It has a couple of problems
     * Firstly, there are 7 psychoacoustic bands subbass to brilliance
     * This algorithm creates 8 bands. The frequency range of the 8 bands also 
     * dont match up to the frequency range of the 7 psychoacoustic bands
     * Also it uses a binWidth of 43Hz, but the actual bin width is
     * AudioSettings.outputSampleRate / 2 / frameSize;
     * Which on my computer is 46Hz because AudioSettings.outputSampleRate is
     * 48000 instead of 44100. 
     * See also https://docs.unity3d.com/ScriptReference/AudioSource.GetSpectrumData.html
    /*
       void GetFrequencyBands()
       {
           int count = 0;

           // 22050 / 512 = 43Hz per sample?
           float binWidth = 43;
           for (int i = 0; i < 8; i++)
           {
               float average = 0;
               int sampleCount = (int)Mathf.Pow(2, i) * 2;
               if (i == 7)
               {
                   sampleCount += 2;
               }
               int nextCount = count + (sampleCount);
               //Debug.Log(i + "\t" + count + "\t" + nextCount + "\t" + (count * binWidth) + "\t" + nextCount * binWidth);

               for (int j = 0; j < sampleCount; j++)
               {
               average += spectrum[count] * (count + 1);
                   count++;
               }
               average /= count;
               bands[i] = average;
           }
       }
       */


    // From: https://answers.unity.com/questions/157940/getoutputdata-and-getspectrumdata-they-represent-t.html
    public float rmsValue = 0;
    public float dbValue = 0;
    public float refValue = 0.1f;
    public float threshold = 0.02f;
    public float pitchValue = 0;
    private float fSample;

    void AnalyzeSound()
    {
        a.GetOutputData(samples, 0); // fill array with samples
        int i;
        float sum = 0;
        for (i = 0; i < frameSize; i++)
        {
            sum += samples[i] * samples[i]; // sum squared samples
        }
        rmsValue = Mathf.Sqrt(sum / frameSize); // rms = square root of average
        dbValue = 20 * Mathf.Log10(rmsValue / refValue); // calculate dB
        if (dbValue < -160) dbValue = -160; // clamp it to -160dB min
                                            // get sound spectrum
        a.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        int maxN = 0;
        for (i = 0; i < frameSize; i++)
        { // find max 
            if (spectrum[i] > maxV && spectrum[i] > threshold)
            {
                maxV = spectrum[i];
                maxN = i; // maxN is the index of max
            }
        }
        float freqN = maxN; // pass the index to a float variable
        if (maxN > 0 && maxN < frameSize - 1)
        { // interpolate index using neighbours
            var dL = spectrum[maxN - 1] / spectrum[maxN];
            var dR = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        pitchValue = freqN * (fSample / 2) / frameSize; // convert index to frequency
    }

    void GetFrequencyBands()
    {        
        for (int i = 0; i < bands.Length; i++)
        {
            int start = (int)Mathf.Pow(2, i) - 1;
            int width = (int)Mathf.Pow(2, i);
            int end = start + width;
            float average = 0;
            for (int j = start; j < end; j++)
            {
                average += spectrum[j] * (j + 1);
            }
            average /= (float) width;
            bands[i] = average;
           // Debug.Log(i + "\t" + start + "\t" + end + "\t" + start * binWidth + "\t" + (end * binWidth));
        }

    }
    
    
    // Update is called once per frame
    void Update () {
        AnalyzeSound();
        GetFrequencyBands();
    }
}
