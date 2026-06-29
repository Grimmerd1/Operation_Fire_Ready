using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void Level5()
   {
        SceneManager.LoadScene("Level 5");
   }
   public void Level1()
   {
        SceneManager.LoadScene("Level 1");
   }
   public void Level2()
   {
        SceneManager.LoadScene("Level 2");
   }
   public void Level3()
   {
        SceneManager.LoadScene("Level 3");
   }
}
