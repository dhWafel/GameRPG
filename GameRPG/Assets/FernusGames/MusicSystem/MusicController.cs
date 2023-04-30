namespace FernusGames.MusicSystem{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class MusicController : MonoSingleton<MusicController>{
        private int SoundNumber;

        public AudioClip[] ArrayAudioClip;

        public bool mute;

        public Button MuteButton;

        public Sprite muteSprite;
        public Sprite musicSprite;

        public AudioSource Sounds;
        private void Start()
        {
            SoundNumber = PlayerPrefs.GetInt("soundInt", 1);
            mute = PlayerPrefs.GetInt("muteOn", 0) == 1;

            Sounds.clip = ArrayAudioClip[SoundNumber];

            MuteButton.image.overrideSprite = PlayerPrefs.GetInt("muteOn", 0) == 1 ? muteSprite : musicSprite;

            if (!mute)
            {
                Sounds.Play();
            }
        }

        public void SwitchMusic()
        {
            PlayerPrefs.SetInt("muteOn", PlayerPrefs.GetInt("muteOn", 0) == 0 ? 1 : 0);
            if (PlayerPrefs.GetInt("muteOn", 0) == 0)
            {
                Sounds.Play();
            }
            else
            {
                Sounds.Stop();
            }
            MuteButton.image.overrideSprite = PlayerPrefs.GetInt("muteOn", 0) == 1 ? muteSprite : musicSprite;
        }
    }


}
