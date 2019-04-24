using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    // Add in a inspector message for the bool bellow to tell the designer to only tick this if it needs to be the correct mirror/final mirror in a puzzle room/level.
    [SerializeField] bool Stuffname = false; // TODO: A better nmame is needed!
     SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get SpriteRenderer here?
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject gameObject) // Maybe because it bounces off, it doesn't Enter and thus OnCollision Enter doesn't get called.
                                                           // Maybe it needs to be more than discrete, could be continous.
    {                                           // What about if it's positive or negative/the final mirror in a level/puzzle?
        // Get Sprite Renderer                  // Get the Sprite Renderer changing colour first. Then work if conditions.
        // SpriteRenderer set color red
         spriteRenderer.color = Color.red; // This could be replaced with a sound to reprsent it later and maybe even some kind of particle effect 
                                          // or light and that glows around the Mirror that resets after a few seconds.
    }

    // Just some notes: The set color.red stuff above needs to set it as that if it's not the final mirror, we'll call that winMirror.
    // What can serialize? Can we serialize a tickable box? If box ticked then you are winMirror. By default set it to un-ticked as most will be un-ticked.
    // 

}
