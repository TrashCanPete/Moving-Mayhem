using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Countdown : MonoBehaviour
{
    TextMeshProUGUI text;
    int count = 3;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Count());
    }
    IEnumerator Count()
    {
        text.text = "";
        yield return new WaitForSeconds(1);
        while (count > 0)
        {
            text.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }
        GameEvents.Instance.GameStart.Invoke();
        text.text = "GO!";
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
