using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void SetUp()
    {
        gameObject.SetActive(true);
        
    }

    public void ReiniciarButton()
    {
        SceneManager.LoadScene("_Complete-Game");
    }
}
