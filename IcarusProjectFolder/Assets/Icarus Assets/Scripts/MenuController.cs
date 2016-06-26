using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

    //These are the references to the main menu objects
    public GameObject newGameMenu, loadGameMenu, multiplayerMenu, optionsMenu, exitMenu;
    public Text newGameButton, loadGameButton, multiplayerButton, optionsButton, exitButton;

    //These are the references to the options menu objects
    public GameObject graphicMenu, audioMenu, gameplayMenu;
    public Text graphicButton, audioButton, gameplayButton;

    //Button colors
    public Color notOpen, Open;

    //Overloaded function, used by cancel buttons
    public void CloseMenus()
    {
        CloseMenus(null);
    }

    //Main Menu Button Function
    public void CloseMenus(Text i)
    {
        //Closes all panels
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        multiplayerMenu.SetActive(false);
        optionsMenu.SetActive(false);
        exitMenu.SetActive(false);
        
        //Colors all buttons to notOpen
        newGameButton.color = notOpen;
        loadGameButton.color = notOpen;
        multiplayerButton.color = notOpen;
        optionsButton.color = notOpen;
        exitButton.color = notOpen;

        //Colors the open button to Open
        if(i != null)
          i.color = Open;

        //Note: The panel you want to open has to be setActive using the OnClick GUI under each button
    }

    //Exits Program
   public void ExitGame()
    {
        Application.Quit();
    }

    //Options Menu Button Function
    public void CloseOptionMenus(Text i)
    {
        //Closes all panels
        graphicMenu.SetActive(false);
        audioMenu.SetActive(false);
        gameplayMenu.SetActive(false);

        //Colors all buttons to notOpen
        graphicButton.color = notOpen;
        audioButton.color = notOpen;
        gameplayButton.color = notOpen;

        //Colors the open button to Open
        i.color = Open;

        //Note: The panel you want to open has to be setActive using the OnClick GUI under each button
    }


}
