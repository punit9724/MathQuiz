using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hompanlscript : MonoBehaviour
{
    [SerializeField]
    Button MusicButton, SoundButton;
    [SerializeField]
    Sprite soundon, soundoff, musicon, musicoff;
    [SerializeField]
    AudioClip soundclip, musicclips;
    [SerializeField]
    GameObject homepanel, lodingpanel, playpanel,settingPanel;
    [SerializeField]
    Slider lodingslider;
    float slidervalue = 1f;
    float Maxvalue ;

    [SerializeField]
    Image lodingimg;
    bool playbtn;

   
    public void Start()
    {
        SoundSet();
        MusicSet();
    }
    public void Homepanel()
    {
        //Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        homepanel.SetActive(true);
        playpanel.SetActive(false);
        
    }
    public void Lodingpanel()
    {
        
        lodingpanel.SetActive(true);
        homepanel.SetActive(false);
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        playbtn = true;
    }
   public  void SettingPanel()
    {
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        settingPanel.SetActive(true);   

    }
    public void Settingbackbtn()
    {
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        homepanel.SetActive(true);
        settingPanel.SetActive(false);  
    }

    private void Update()
    {
        if (playbtn)
        {
            
            if (lodingimg.fillAmount < 1)
            {
                
                lodingimg.fillAmount = lodingimg.fillAmount + slidervalue * Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        //if (playbtn)
        //{
        //    if (lodingslider.value < Maxvalue)

        //    {
        //        lodingslider.value = lodingslider.value + slidervalue;
        //    }
        //    else
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //    }

        //}



    }
    public void SoundImageManager()
    {
        if (Common.Instance.SoundBool)
        {
         
            Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            SoundButton.GetComponent<Image>().sprite = soundoff;
            Common.Instance.SoundBool = false;
        }
        else
        {
           
            Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            SoundButton.GetComponent<Image>().sprite = soundon;
            Common.Instance.SoundBool = true;
        }
    }

    //  Music Image Manager
    public void MusicImageManager()
    {
        if (Common.Instance.MusicBool)
        {
            Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
            Common.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
            MusicButton.GetComponent<Image>().sprite = musicoff;
            Common.Instance.MusicBool = false;
        }
        else
        {
            Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
            Common.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = false;
            MusicButton.GetComponent<Image>().sprite = musicon;
            Common.Instance.MusicBool = true;
        }
    }

    // SoundSet Dynamic
    public void SoundSet()
    {
        if (Common.Instance.SoundBool)
        {
           
            Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            SoundButton.GetComponent<Image>().sprite = soundon;
        }
        else
        {
           
            Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            SoundButton.GetComponent<Image>().sprite = soundoff;
        }
    }

    // MusicSet Dynamic
    public void MusicSet()
    {
        if (Common.Instance.MusicBool)
        {
           
            Common.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = false;
            MusicButton.GetComponent<Image>().sprite = musicon;
        }
        else
        {
            
            Common.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
            MusicButton.GetComponent<Image>().sprite = musicoff;
        }
    }

}