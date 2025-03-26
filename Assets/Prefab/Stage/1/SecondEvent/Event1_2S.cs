using UnityEngine;
using System;
using System.IO;
using System.Text;

public class Event1_2S : MonoBehaviour
{
    [SerializeField] private GameObject pos1;
    [SerializeField] private GameObject pos2;
    [SerializeField] private GameObject pos3;
    [SerializeField] private GameObject pos4;
    [SerializeField] private GameObject woman;
    
    // Start is called before the first frame update
    void Start()
    {
            FileStream fstream1 = File.Create("fileA.txt");
            FileInfo file = new FileInfo("fileB.txt");
            FileStream fstream2 = file.Create();
            fstream1.Close();
            fstream2.Close();
            File.Copy("fileA.txt", "fileC.txt");
            FileInfo dst = file.CopyTo("fileD.txt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(woman, pos1.transform.position, pos1.transform.rotation);
            Instantiate(woman, pos1.transform.position, pos1.transform.rotation);
            Instantiate(woman, pos2.transform.position, pos2.transform.rotation);
            Instantiate(woman, pos2.transform.position, pos2.transform.rotation);
            Instantiate(woman, pos3.transform.position, pos3.transform.rotation);
            Instantiate(woman, pos3.transform.position, pos3.transform.rotation);
            Instantiate(woman, pos3.transform.position, pos3.transform.rotation);
            Instantiate(woman, pos4.transform.position, pos4.transform.rotation);
            Instantiate(woman, pos4.transform.position, pos4.transform.rotation);
            Instantiate(woman, pos4.transform.position, pos4.transform.rotation);
            Instantiate(woman, pos4.transform.position, pos4.transform.rotation);
            Destroy(gameObject);
        }
    }
}
