using UnityEngine;
using System.Collections;

public class GunAnimationController : MonoBehaviour {

    public static GunAnimationController instance { get; private set; }
    public Animator recoilAnimator;

    // Use this for initialization
    void Start () {
        instance = this;
	}

    public void Recoil()
    {
        GetComponent<Animator>().Play("recoil", -1, 0f);
    }
}
