using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    bool ready = false;
    [SerializeField] private List<GameObject> backgroundImages;
    [SerializeField] private GameObject currentBackgroundImage;
    [SerializeField] private GameStateSO gameState;
    // Start is called before the first frame update
    void Start()
    {
        switch (gameState.EncounterIndex)
        {
            case 1:
            case 2:
                currentBackgroundImage = backgroundImages[0];
                break;
            case 3:
                currentBackgroundImage = backgroundImages[1];
                break;
            case 4:
            case 5:
                currentBackgroundImage = backgroundImages[2];
                break;
            case 6:
                currentBackgroundImage = backgroundImages[3];
                break;
            case 7:
            case 8:
                currentBackgroundImage = backgroundImages[4];
                break;
            case 9:
                currentBackgroundImage = backgroundImages[5];
                break;
                default:
                SceneManager.LoadScene("Credits");
                break;

        }
        Instantiate(currentBackgroundImage);
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && ready)
        {
            SceneManager.LoadScene("Fight");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        ready = true;
    }
}
