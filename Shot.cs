using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject gameController;
    private bool isMoving;

    public delegate void EventHandler();

    public static event EventHandler OnSomeChanged;

    private AudioSource audioSource;
    public AudioClip soundKilled;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WoodenMan"))
        {
            gameController.SendMessage("AddScore");
            audioSource.PlayOneShot(soundKilled);
            Destroy(other.gameObject);
        } else if (other.CompareTag("BreakPoint"))
        {
            gameController.SendMessage("ViewGameEndScreen");
            Destroy(gameObject);
        }
    }

    public void ShotCube()
    {
        OnSomeChanged();
        Invoke(nameof(MoveThis), 2.0f);        
    }

    private void MoveThis()
    {
        isMoving = true;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isMoving = false;
    }
    private void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(0, 0, 20) * Time.deltaTime;
        }
    }
}
