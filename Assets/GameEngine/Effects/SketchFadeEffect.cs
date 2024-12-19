using UnityEngine;
using System.Collections;

public class SketchFadeEffect : MonoBehaviour {

    public SpriteRenderer sprite;
   public  float fadeTimer = 5;
    void Start() {
        
        StartCoroutine(spriteEffect());

    }


    IEnumerator spriteEffect() {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject newSprite = (GameObject)Instantiate(sprite.gameObject, sprite.gameObject.transform.position, sprite.gameObject.transform.rotation);
            newSprite.transform.parent = SketchLinesContainer.instance.transform;
            StartCoroutine(Fade(newSprite.GetComponent<SpriteRenderer>()));
            

        }


    }

    IEnumerator Fade(SpriteRenderer sprite)
    {
        yield return new WaitForSeconds(fadeTimer);

        float lerper = 0;
        float lerpTime = 1;
        Color targetColor = sprite.color;
        Color startColor = sprite.color;
        targetColor.a = 0;

        while (lerper < 1)
        {


            lerper += Time.deltaTime / lerpTime;
            sprite.color = Color.Lerp(startColor, targetColor, lerper);
            yield return new WaitForEndOfFrame();

        }
        Destroy(sprite.gameObject);

    }

}
