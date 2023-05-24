using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public bool canShoot;
    public float powerUpDuration = 5;
    public float powerUpTimer = 0;

    public Text coinText;
    int coins;

    public List<GameObject> enemiesInScreen;

    void Update()
    {
        ShootPowerUp();

        if(Input.GetKeyDown(KeyCode.P))
        {
            KillAllEnemies();
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        //Llamar funcion de forma normal
        //LoadScene();

        //Invocamos la funcion despues de 1.5 segundos
        //Invoke("LoadScene", 2.5f);

        //Llamamos la corutina LoadScene
        StartCoroutine("LoadScene");
    }

    /*void LoadScene()
    {
        SceneManager.LoadScene(0);
    }*/

    IEnumerator LoadScene()
    {
        //Esto para la corutina durante 2.5 segundos
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(0);
    }

    public void AddCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }

    void ShootPowerUp()
    {
        if(canShoot)
        {
            if(powerUpTimer <= powerUpDuration)
            {
                powerUpTimer += Time.deltaTime;
            }
            else
            {
                canShoot = false;
                powerUpTimer = 0;
            }
        }
    }

    void KillAllEnemies()
    {
        /*for (int i = 0; i < enemiesInScreen.Count; i++)
        {
            Destroy(enemiesInScreen[i]);
        }*/

        foreach (GameObject enemigo in enemiesInScreen)
        {
            Destroy(enemigo);
        }
    }
}
