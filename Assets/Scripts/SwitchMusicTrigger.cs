using UnityEngine;
using UnityEngine.Audio;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;
    private AudioManager AM;
    // Start is called before the first frame update
    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
     Debug.Log("in music trigger");
        if (other.tag == "Player")
        {
            if (newTrack != null)
            {
                AM.ChangeBGM(newTrack);
                Debug.Log("track has been switched");
            }
        }
    }
}
