using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ScreenFader screenFader;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    // This method is linked to the button for the void scene
    public void PlayVoidScene(){
        screenFader.FadeToColor("void");
    }

    // This method is linked to the button for the cave scene
    public void PlayCaveScene(){
        screenFader.FadeToColor("cave");
    }

    // This method is linked to the button for the rain scene
    public void PlayRainScene(){
        screenFader.FadeToColor("rain");
    }

     public void PlayCampfireScene(){
        screenFader.FadeToColor("campfire");
    }

    public void Quit(){
        Application.Quit();
    }
}
