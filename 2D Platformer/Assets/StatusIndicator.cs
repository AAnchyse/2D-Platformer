using UnityEngine;
using UnityEngine.UI; 

public class StatusIndicator : MonoBehaviour {

   // [SerializeField] private
    public RectTransform healthBarRect;
   // [SerializeField] private //clairement je comprends pas à quoi ça sert
    public Text healthText;

    private void Start()
    {
        if(healthBarRect==null)
        {
            Debug.LogError("No health bar object");
        }
        if (healthText== null)
        {
            Debug.LogError("No health text object");
        }
    }

    public void SetHealth (int cur, int max)
    {
        float value = (float)cur / max;

        healthBarRect.localScale = new Vector3(value,healthBarRect.localScale.y, healthBarRect.localScale.z);
        healthText.text = cur + "/" + max + " HP";
    }

}
