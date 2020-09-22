using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class ReloadMenu : MonoBehaviour
{
    //YEA I WAS LAZY AND HARD CODED A SECOND SCENE LOAD SCRIPT FIGHT ME
    public TextMeshProUGUI T;
    public Button B;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scroll());
    }

    IEnumerator Scroll()
    {
        while (T.rectTransform.localPosition.y < 370)
        {
            
            T.rectTransform.localPosition = new Vector3(T.rectTransform.localPosition.x, T.rectTransform.localPosition.y + 1, T.rectTransform.localPosition.z);
            B.GetComponent<RectTransform>().localPosition = new Vector3(B.GetComponent<RectTransform>().localPosition.x, B.GetComponent<RectTransform>().localPosition.y + 1, B.GetComponent<RectTransform>().localPosition.z);
            yield return new WaitForSeconds(0.025f);
        }


        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        SceneManager.LoadScene(0);

    }

    
}
