using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeParticles : MonoBehaviour {
    //Going to try and get this script working to use on the particles.
    //So far, the things I have gathered is
    //Good fucking god, just fucking set your color equal to the current color
    //...
    //Fucking bitch

    // public float fadeTime = 2;
    private Renderer ren;
    public void fadeObject(float val, float time)
    {
        ren = GetComponent<Renderer>();
        StartCoroutine(fadeTo(val, time));
    }

    //Fucking stole this shit
    //https://answers.unity.com/questions/225438/slowly-fades-from-opaque-to-alpha.html
    public IEnumerator fadeTo(float aValue, float aTime)
    {
        Debug.Log("Started");

        float alpha = ren.material.color.a;
        // Color col = GetComponent<Renderer>().material.color;
       
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            // Debug.Log(col.a);
            Color newCol = new Color(ren.material.color.r, ren.material.color.g, ren.material.color.b, Mathf.Lerp(alpha, aValue, t));
            //Debug.Log(col + " " + newColor);
            ren.material.color = newCol;
            yield return null;
        }
        Destroy(gameObject);
    }

}
