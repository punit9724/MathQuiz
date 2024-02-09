using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

using Unity.Burst.Intrinsics;
using UnityEngine.SocialPlatforms.Impl;

public class plyscript : MonoBehaviour
{
    [SerializeField]
    GameObject playpanel, gamepanel, plusbtn,settingpanel,Generatedanswer,gameoverpanel, pausepanel;
    [SerializeField]
    Sprite soundon, soundoff, musicon, musicoff;
    [SerializeField]
    Image timeoutslider;
    bool Plusbtn = false;
    [SerializeField]
    Button MusicButton,SoundButton;
    
    [SerializeField]
    AudioClip soundclip, musicclips;
        


    [SerializeField] 
    List<float> optionvalue;
    float slidervalue = 0.2f;
    bool sliderstop=false;
    [SerializeField]
    TextMeshProUGUI firsttxt, secondtxt, opreatortxt,ScoreTxt;
    [SerializeField]
    TextMeshProUGUI[]fouroption;

    float selectedfeild;
    int num1, num2, ans;
    bool flag=false;
   public Animation anim;
    int score = 1;
    public void Start()
    {
        SoundSet();
        MusicSet();
        //MusicImageManager();
        //SoundImageManager();
    }
    public void settingbackbtn()
    {
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
      settingpanel.SetActive(false);    
    }


    public void Homepanel()
    {
        Common.Instance.gameObject.transform.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        SceneManager.LoadScene("mainmenu");
    }

    public void methodbtn(int value)
    {
        //StartCoroutine("iconanim");
        selectedfeild = value;
        gamepanel.SetActive(true);
        playpanel.SetActive(false);
        Pluspanel();
        Common.Instance.gameObject.transform.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);


    }
    

    public void PLAYpanel()
    {
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        playpanel.SetActive(true);
        settingpanel.SetActive(false);
        gameoverpanel.SetActive(false); 
        gamepanel.SetActive(false);
        pausepanel.SetActive(false);
        settingpanel.SetActive(false);
        
        gamepanel.SetActive(false);
        sliderstop=false;
        


    }
   
    public void Settingpanel()
    {
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        settingpanel.SetActive(true);
        pausepanel.SetActive(false);
        gamepanel.SetActive(false);
        
        sliderstop = false;

    }
    public void Pluspanel()
    {
        gameoverpanel.SetActive(false);
        pausepanel.SetActive(false);
        timeoutslider.fillAmount = 1;
       sliderstop = true;
        Plusbtn = true;
        slidervalue = 0.2f;
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);

        switch (selectedfeild)
        {
            case 1:
                num1 = Random.Range(1, 20);
                num2 = Random.Range(1, 20);
                firsttxt.text = num1.ToString();
                secondtxt.text = num2.ToString();
                ans = num1 + num2;
                opreatortxt.text = "+";
                Debug.Log("ans is" + ans);
                generatedanswer();
                flag = false;
                break;
            case 2:
                do
                {
                    num1 = Random.Range(1, 20);
                    num2 = Random.Range(1, 20);
                    firsttxt.text = num1.ToString();
                    secondtxt.text = num2.ToString();
                    ans = num1 - num2;
                    generatedanswer();
                } while (num1 < num2);
                opreatortxt.text = "-";
                Debug.Log("ans is" + ans);
                flag = false;
                break;
            case 3:
                num1 = Random.Range(1, 11);
                num2 = Random.Range(1, 11);
                firsttxt.text = num1.ToString();
                secondtxt.text = num2.ToString();
                ans = num1 * num2;
                opreatortxt.text = "X";
                generatedanswer();
                Debug.Log("ans is" + ans);
                flag = false;
                break;
            case  4:
                    opreatortxt.text = "/";
                    num2 = Random.Range(1, 9);
                    num1 = num2 *Random.Range(1, 10);
                   
                    firsttxt.text = num1.ToString();
                    secondtxt.text = num2.ToString();
                    ans = num1 / num2;
                    generatedanswer();
                



                break;  
        }
      
    }

    private void Update()
    {
        if (sliderstop)
        {
            if (Plusbtn)
            {
                if (timeoutslider.fillAmount > 0)
                {
                    timeoutslider.fillAmount -=  slidervalue * Time.deltaTime;
                }
                else
                {
                    gameoverpanel.SetActive(true);


                }
            }
        }
    }
   void generatedanswer()
    {
        float randomANS;
        optionvalue.Clear();
        for(int i = 0; i < 3; i ++) 
        {
            do
            {
              
                if(flag)
                {
                    
                   randomANS= Random.Range((int)ans +10,(int) ans +5);
                   float randomas =(int) System.Math.Round(randomANS);
                    randomANS = randomas; 
                }
                else
                {
                    randomANS= Random.Range ((int)ans+10,(int)ans + 5);
                    float ab=System.Math.Abs(randomANS);
                    randomANS = ab;
                }

            } while (optionvalue.Contains(randomANS) || ans == randomANS );
            optionvalue.Add(randomANS);
        }

        setfourbtn();
    }
    void setfourbtn()
    {
        int value;
        int counter = 0;
            value = Random.Range(0,fouroption.Length);
            for(int i = 0;i < fouroption.Length;i++) 
            {
               if(value ==i)
               {
                  if(flag==true) 
                  {
                    fouroption[i].text = ans.ToString();
                        
                   }
                  else
                   {
                    fouroption[i].text =ans.ToString();
                     }
                }
                else
                {
                   fouroption[i].text = optionvalue[counter].ToString();
                   counter++;
                }
            }


    }

    public void setAnswer(TextMeshProUGUI text) 
    
     {
        
       
        
        if (text.text==ans.ToString())
        {
            
            
            ScoreTxt.text=score.ToString();
            ++score;
            Debug.Log("answer is correct");
            Pluspanel();
            

          
        }
        else
        {
            Debug.Log("answer is wrong");
           gameoverpanel.SetActive(true);
            sliderstop = false;
            
        }
      }

   public void PAUSEbtn()
    {
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        pausepanel.SetActive(true);
        playpanel.SetActive(false);
       gamepanel.SetActive(true);
       
       slidervalue = 0.0000000000001f;

        
    }

    public void resume()
    {
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        slidervalue = 0.2f;
        gamepanel.SetActive(true); 
        pausepanel.SetActive(false);
    }
    public void restartbtn()
    {
        Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
        slidervalue = 0.2f;
        Pluspanel();
    }
    //IEnumerator iconanim()
    //{ 
    //    yield return new WaitForSeconds(2f);
    //    // playpanel.SetActive(false);
    //    anim = gameObject.GetComponent<Animation>();
    //    anim.Play("buttonanimrev");
    //    settingpanel.SetActive(true);   
    //}

    // Sound Image Manager
    public void SoundImageManager()
    {
        if (Common.Instance.SoundBool)
        {
            Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
            Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            SoundButton.GetComponent<Image>().sprite = soundoff;
            Common.Instance.SoundBool = false;
        }
        else
        {
            Common.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(soundclip);
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
