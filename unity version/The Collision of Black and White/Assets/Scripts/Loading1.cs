using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading1 : MonoBehaviour
{
    public Scrollbar m_Scrollbar;
    public Text m_Text;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(loadScene());
    }
    IEnumerator loadScene()
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync(Global.GetInstance().loadName2);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }
        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }
    public void SetLoadingPercentage(int DisplayProgress)
    {
        m_Scrollbar.size = DisplayProgress * 0.01f;
        m_Text.text = DisplayProgress.ToString() + "%";
    }

}
