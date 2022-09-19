using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private float enableButtonTime = 15f;

    private void Start()
    {
        button.SetActive(false);
        StartCoroutine(EnableButton());
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(enableButtonTime);
        button.SetActive(true);
    }
}
