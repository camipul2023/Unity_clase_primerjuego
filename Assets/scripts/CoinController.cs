using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
   [SerializeField] private AudioSource esmeralda_SFX; // Campo donde se enlaza el componente de audio desde Unity

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("esmeralda");
        esmeralda_SFX.Play();  // Sonido

        StartCoroutine(goNextLevel(esmeralda_SFX.clip.length)); // Pasa el nivel con un "delay" para que alcance a sonar el audio
        gameObject.GetComponent<Renderer>().enabled = false;      // La moneda desaparece
    }

    // Aquí está la lógica del paso de nivel después de la pausa suficiente para que suene el audio
    private IEnumerator goNextLevel(float delay){
        yield return new WaitForSeconds(delay); 
        Destroy(gameObject);

        if(SceneManager.GetActiveScene().name=="EscenaUno"){
            SceneManager.LoadScene("EscenaDos");
        }
        else{
            Debug.Log(esmeralda_SFX.isPlaying);
            SceneManager.LoadScene("EscenaUno");
        }    
    }
}
