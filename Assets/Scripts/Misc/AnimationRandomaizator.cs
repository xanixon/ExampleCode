using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandomaizator : MonoBehaviour
{
    [SerializeField] private Animator[] fishAnimation;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DesyncronizeFishAnimations(fishAnimation));
    }


    public static IEnumerator DesyncronizeFishAnimations(Animator[] anim)
    {
        foreach (Animator fish in anim)
        {
            fish.gameObject.SetActive(false);
        }

        foreach (Animator fish in anim)
        {
            fish.gameObject.SetActive(true);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0f, 1f));
        }
    }

}
