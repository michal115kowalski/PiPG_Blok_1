using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, coinSound, bumpSound,endSound;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("smw_jump");
        coinSound = Resources.Load<AudioClip>("coin_sound");
        bumpSound = Resources.Load<AudioClip>("bump_sound");
        endSound = Resources.Load<AudioClip>("smb_mariodie");

        audiosrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audiosrc.PlayOneShot(jumpSound);
                break;

            case "coin":
                audiosrc.PlayOneShot(coinSound);
                break;

            case "bump":
                audiosrc.PlayOneShot(bumpSound);
                break;

            case "die":
                audiosrc.PlayOneShot(endSound);
                break;
        }
    }
}
