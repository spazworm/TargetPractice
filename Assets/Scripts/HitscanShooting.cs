using UnityEngine;
using System.Collections;

public class HitscanShooting : MonoBehaviour {

    public Material hitMaterial;
    public Object spark;
    public AudioClip gunshot;
    public AudioClip ding;
    public AudioClip impact;
    public Animator recoilAnimator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1")) {
            GunAnimationController.instance.Recoil();
            var pistol = transform.Find("Pistol");
            var muzzleFlash = pistol.Find("MuzzleFlash");
            muzzleFlash.GetComponent<ParticleSystem>().Emit(20);
            RaycastHit hit;
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
            var layerMask = 1 << 2;
            layerMask = ~layerMask;
            Debug.DrawRay(transform.position, forward, Color.green, 2, true);

            if (Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity, layerMask)) {
                AudioSource.PlayClipAtPoint(gunshot, transform.position);
                AudioSource.PlayClipAtPoint(impact, hit.point);
                Quaternion sparkDirection = Quaternion.FromToRotation(Vector3.forward, hit.normal);
                Object.Instantiate(spark, hit.point, sparkDirection);
                if (hit.collider.gameObject.tag == "ActiveTarget") {
                    AudioSource.PlayClipAtPoint(ding, hit.point);
                    GameObject target = hit.collider.gameObject;
                    target.tag = "InactiveTarget";
                    target.GetComponent<Renderer>().sharedMaterial = hitMaterial;
                    RemaningTargetsTextManager manager = RemaningTargetsTextManager.instance;
                    manager.updateRemainingTargets();
                }
            }
        }
    }
}
