using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour{

    [SerializeField] private TMP_Text timertext;
    [SerializeField, Tooltip("Tiempo en segundos") ] private float timerTime;

    private int minutes, seconds, cents;
    private void Update()
    {

        timerTime -= Time.deltaTime;

        if(timerTime == 0){
            //cargar escena de estadisticas
            SceneManager.LoadScene("Estadisticas");
        }

        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime - minutes * 60f);
        cents = (int)((timerTime-(int)timerTime) *100f);

        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}