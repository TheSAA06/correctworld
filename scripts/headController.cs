using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headController : MonoBehaviour
{
    int tree = 0;
    int stone = 0;
    public Text treeCountText;
    public Text stoneCountText;
    public GameObject picaxe;
    public GameObject axe;
    int picaxehave = 0;
    int axehave = 0;
    public Transform playerBody;
    float xRotate = 0f;
    public float sens = 140f;
    //Components
    Transform tr;
    //DrawRay
    public GameObject pressE;
    void Start()
    {
        tr = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Движение
        pressE.SetActive(false);
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        //DrawRay
        Debug.DrawRay(tr.position, tr.forward * 3f , Color.red);
        RaycastHit objects;
        if(Physics.Raycast(tr.position, tr.forward, out objects, 4f))
        {
            if(objects.collider.gameObject.tag == "tree")
            {
                pressE.SetActive(true);
                if(Input.GetKeyDown("e"))
                {
                    Destroy(objects.collider.gameObject);
                    if(axehave <= 0)
                    {
                        tree++;
                    }
                    if(axehave >= 1)
                    {
                        tree = tree + 3;
                    }
                    treeCountText.text = "Дерево "+tree;
                }
            }
            if(objects.collider.gameObject.tag == "stone")
            {
                pressE.SetActive(true);
                if(picaxehave >= 1)
                {
                    if(Input.GetKeyDown("e"))
                    {
                        Destroy(objects.collider.gameObject);
                        stone = stone + 3;
                        stoneCountText.text = "Камень "+stone;
                    }
                }
            }
            if(objects.collider.gameObject.tag == "smallstone")
            {
                pressE.SetActive(true);
                if(Input.GetKeyDown("e"))
                {
                    Destroy(objects.collider.gameObject);
                    stone = stone + 1;
                    stoneCountText.text = "Камень "+stone;
                }
            }
        //craft
            if(picaxehave <= 0)
            {
                if(stone >= 2 && tree >= 2)
                {
                    picaxe.SetActive(true);
                    picaxehave = 1;
                    stone = stone - 2;
                    stoneCountText.text = "Камень "+stone;
                    tree = tree - 2;
                    treeCountText.text = "Дерево "+tree;
                }
            }
            if(axehave <= 0)
            {
                if(stone >= 3 && tree >= 3)
                {
                    axe.SetActive(true);
                    axehave = 1;
                    stone = stone - 3;
                    stoneCountText.text = "Камень "+stone;
                    tree = tree - 3;
                    treeCountText.text = "Дерево "+tree;
                }
            }
        }
    }
}
