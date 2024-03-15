using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    //BackgroundMusic
    public GameObject MenuMusic;
    public GameObject Level1Music;
    public GameObject Level2Music;
    public GameObject Level3Music;
    //CarSoundEffects
    public GameObject WindSFX;
    public GameObject AccellSFX;
    public GameObject BoostSFX;
    public GameObject BreakSFX;
    public GameObject DriftSFX;
    public GameObject IdleSFX;
    //Gameplay Sound Effects
    public GameObject Countdown1;
    public GameObject Countdown2;
    //Menu Sound Effects
    public GameObject ButtonHover;
    public GameObject ButtonClick1;
    public GameObject ButtonClick2;
    public GameObject ButtonClick3;
    public GameObject ButtonClick4;
    public GameObject ButtonClick5;
    public GameObject ButtonClick6;
    public GameObject ButtonClick7;
    public GameObject ButtonClick8;
    public GameObject ButtonClick9;
    public GameObject ButtonClick10;
    public GameObject ButtonClick11;
    public GameObject ButtonClick12;
    public GameObject ButtonClick13;
    public GameObject ButtonClick14;
    public GameObject ButtonClick15;
    public GameObject ButtonClick16;


    //BackgroundMusic
    private AudioClip menuMusic;
    private AudioClip level1Music;
    private AudioClip level2Music;
    private AudioClip level3Music;
    //CarSoundEffects
    private AudioClip windSFX;
    private AudioClip accellSFX;
    private AudioClip boostSFX;
    private AudioClip breakSFX;
    private AudioClip driftSFX;
    private AudioClip idleSFX;
    //Gameplay Sound Effects
    private AudioClip countdown1;
    private AudioClip countdown2;
    //Menu Sound Effects
    private AudioClip buttonHover;
    private AudioClip buttonClick1;
    private AudioClip buttonClick2;
    private AudioClip buttonClick3;
    private AudioClip buttonClick4;
    private AudioClip buttonClick5;
    private AudioClip buttonClick6;
    private AudioClip buttonClick7;
    private AudioClip buttonClick8;
    private AudioClip buttonClick9;
    private AudioClip buttonClick10;
    private AudioClip buttonClick11;
    private AudioClip buttonClick12;
    private AudioClip buttonClick13;
    private AudioClip buttonClick14;
    private AudioClip buttonClick15;
    private AudioClip buttonClick16;

    private void Start()
    {
        //accessing background music clips off game objects...
        menuMusic = MenuMusic.GetComponent<AudioClip>();
        level1Music = Level1Music.GetComponent<AudioClip>();
        level2Music = Level2Music.GetComponent<AudioClip>();
        level3Music = Level3Music.GetComponent<AudioClip>();
        //accessing car clips off game objects...
        windSFX = WindSFX.GetComponent<AudioClip>();
        accellSFX = AccellSFX.GetComponent<AudioClip>();
        boostSFX = BoostSFX.GetComponent<AudioClip>();
        breakSFX = BreakSFX.GetComponent<AudioClip>();
        driftSFX = DriftSFX.GetComponent<AudioClip>();
        idleSFX = IdleSFX.GetComponent<AudioClip>();
        //accessing gameplay clips from game objects...
        buttonHover = ButtonHover.GetComponent<AudioClip>();
        buttonClick1 = ButtonClick1.GetComponent<AudioClip>();
        buttonClick2 = ButtonClick2.GetComponent<AudioClip>();
        buttonClick3 = ButtonClick3.GetComponent<AudioClip>();
        buttonClick4 = ButtonClick4.GetComponent<AudioClip>();
        buttonClick5 = ButtonClick5.GetComponent<AudioClip>();
        buttonClick6 = ButtonClick6.GetComponent<AudioClip>();
        buttonClick7 = ButtonClick7.GetComponent<AudioClip>();
        buttonClick8 = ButtonClick8.GetComponent<AudioClip>();
        buttonClick9 = ButtonClick9.GetComponent<AudioClip>();
        buttonClick10 = ButtonClick10.GetComponent<AudioClip>();
        buttonClick11 = ButtonClick11.GetComponent<AudioClip>();
        buttonClick12 = ButtonClick12.GetComponent<AudioClip>();
        buttonClick13 = ButtonClick13.GetComponent<AudioClip>();
        buttonClick14 = ButtonClick14.GetComponent<AudioClip>();
        buttonClick15 = ButtonClick15.GetComponent<AudioClip>();
        buttonClick16 = ButtonClick16.GetComponent<AudioClip>();
    }


    private void Update()
    {
        
    }























}
