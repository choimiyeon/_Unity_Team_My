using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadsceneToDaily : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Daily");
    }
}