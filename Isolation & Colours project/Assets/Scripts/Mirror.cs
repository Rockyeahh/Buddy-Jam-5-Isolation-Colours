using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mirror : MonoBehaviour
{
    [Tooltip ("Leave unticked unless it is the final mirror in the level/puzzle.")]
    [SerializeField] bool CurrentMirrorstate = false; // TODO: A better name is needed!
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject gameObject)
    {
        print("colliision");
        if (CurrentMirrorstate == false)
        {
            spriteRenderer.color = Color.red; // This could be replaced with a sound to reprsent it later and maybe even some kind of particle effect 
                                              // or light and that glows around the Mirror that resets after a few seconds.
            print("Set to Red");
        } else if (CurrentMirrorstate == true)
        {
            spriteRenderer.color = Color.blue;
            print("Set to Blue");
            print("Level complete. Load next level or open door/wall to the next level.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Just some notes: The set color.red stuff above needs to set it as that if it's not the final mirror, we'll call that winMirror.
    // What can serialize? Can we serialize a tickable box? If box ticked then you are winMirror. By default set it to un-ticked as most will be un-ticked.
    // 

}
