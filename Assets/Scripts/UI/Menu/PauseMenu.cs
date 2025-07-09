using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : Menu
{
    [SerializeField] private OptionsMenu OptionsMenu;
    [SerializeField] private List<GameObject> overlayObjects;

    public override void ActivateMenu()
    {
        base.ActivateMenu();
    }

    public void ActivateMenu(bool fromGameplay)
    {
        if (fromGameplay)
        {
            gameObject.transform.parent.gameObject.SetActive(true);
            GameManager.Instance.SetGameState(GameManager.GameState.Paused);
            foreach (var obj in overlayObjects)
                obj.SetActive(false);
        }
        else
            ActivateMenu();

    }

    public void DeactivateMenu(bool toGamePlay)
    {
        if (toGamePlay)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            GameManager.Instance.SetGameState(GameManager.GameState.Gameplay);
            foreach (var obj in overlayObjects)
                obj.SetActive(true);
        }
        else
            DeactivateMenu();
            
    }

    public void GoToOptionMenu()
    {
        OptionsMenu.ActivateMenu();
        DeactivateMenu();
    }

    public void ReturnToMainMenu()
    {
        PersistentObject.instance.DestroyThisWhenQuit();
        PlayerStats.Instance.DestroyThisWhenQuit();
        GameManager.Instance.DestroyThisWhenQuit();
        SceneManager.LoadSceneAsync("TitleScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
