using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _cam;
    private bool _canFire = false;
    void Start() {
        _cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update() {
        if(_canFire){
            if (Input.GetMouseButtonDown(0)) {
                Vector3 point = new Vector3(_cam.pixelWidth / 2, _cam.pixelHeight / 2, 0);
                Ray ray = _cam.ScreenPointToRay(point);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    GameObject hitObject = hit.transform.gameObject;
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                    if (target != null) {
                        target.ReactToHit();
                    } else {
                        StartCoroutine(SphereIndicator(hit.point));
                    }
                }
            }
        }
        
    }

    public void EnableWeapon(){
        _canFire = true;
    }

    public bool WeaponInstance(){
        return _canFire;
    }

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    void OnGUI() {
        int size = 20;
        float posX = _cam.pixelWidth/2 - size/4;
        float posY = _cam.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}
