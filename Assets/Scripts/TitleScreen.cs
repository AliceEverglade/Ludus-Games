using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameStateSO gameState;
    bool ready = false;
    // Start is called before the first frame update
    void Start()
    {
        gameState.EncounterIndex = 4;
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && ready)
        {
            SceneManager.LoadScene("Map");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        ready = true;
    }
}
