using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
public class PlayerSoundEffects : MonoBehaviour
{
    private AudioManager walkAudioManager, runAudioManager;
    private List<AudioClip> footStepAudioClips;
    private PlayerMovements playerMovements;
    private AudioSource audioSource;
    public string pathToSoundFolder = "file://" + Application.streamingAssetsPath + "/sound_effects/";
    void Start()
    {
        footStepAudioClips = AudioClipsByRange(7);
        audioSource = GetComponent<AudioSource>();
        playerMovements = GetComponent<PlayerMovements>();
        walkAudioManager = new AudioManager(audioSource, footStepAudioClips, playerMovements.IsWalking(), 100);
        runAudioManager = new AudioManager(audioSource, footStepAudioClips, playerMovements.IsRunning(), 100);
    }

    void Update()
    {
       walkAudioManager.ActivateAudioManagerMultipleMode();
       runAudioManager.ActivateAudioManagerMultipleMode();
       audioSource.PlayOneShot(footStepAudioClips[0]);
       Debug.Log(footStepAudioClips[0]);
    }
    /*
    Returns a list of AudioClips taken from a specific folder and a rangeBound which defines
    how much AudioClips are required to be returned (The files name have to be numbers so that the rangeBound actually works)
    */
    private List<AudioClip> AudioClipsByRange(int rangeBound)
    {
        List<AudioClip> result = new List<AudioClip>();
        for (int i = 0; i < rangeBound + 1; i++)
        {
            result.Add(GetAudioFromFile(rangeBound.ToString() + ".ogg"));
        }
        return result;
    }
    public AudioClip GetAudioFromFile(string filename)
    {
        string audioToLoad = string.Format(pathToSoundFolder + "{0}", filename);
        WWW request = new WWW(audioToLoad);
        return request.GetAudioClip();
    }
}
