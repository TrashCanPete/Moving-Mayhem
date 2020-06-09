using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BonusDisplay : MonoBehaviour
{
    public GameObject display;
    public static BonusDisplay bonusScript;
    const float waitTime = 3;
    const float offset = 0.08f;
    const int max = 4;
    List<GameObject> bonuses = new List<GameObject>();
    private void Start()
    {
        bonusScript = this;
    }
    public static void ShowBonus(string text, float bonus)
    {
        if (bonusScript != null)
            bonusScript.Show(text, bonus);
    }
    public void Show(string text, float bonus)
    {
        GameObject go = Instantiate(display, transform);
        TextMeshProUGUI textElement = go.GetComponentInChildren<TextMeshProUGUI>();
        textElement.text = text + " +" + bonus;
        foreach(GameObject g in bonuses)
        {
            g.transform.Translate(Vector3.up * offset);
        }
        if (bonuses.Count > max)
        {
            Destroy(bonuses[0]);
        }
        bonuses.Add(go);
        StartCoroutine(RemoveTime(go));
    }
    IEnumerator RemoveTime(GameObject go)
    {
        yield return new WaitForSeconds(waitTime);
        if (go != null)
        {
            bonuses.Remove(go);
            Destroy(go);
        }
    }
}
