using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;
public class enemy : MonoBehaviour
{
    [SerializeField] Transform target;
   public NavMeshAgent navMesh;
   public Animator berryanimator;
    public TextMeshProUGUI playerScoreText;
   public int lives=9;
    // Start is called before the first frame update
    void Start()
    {
        //navMesh = gameObject.GetComponent<NavMeshAgent>;
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(target.position);
        playerScoreText.text =  lives.ToString()+ " lives left!";

    }
     private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Jubi Died :(");
            berryanimator.SetTrigger("dying");
            //Destroy(other.gameObject);
            lives--;
            

        }
    }
     public void Respawn(){
       
            transform.position = new Vector3(0, 0.14f, 50);
            if (lives<=0){
                SceneManager.LoadScene("SampleScene");
            }
        }
        public void Refresh(){
                transform.position = new Vector3(0, 0.14f, 50);
                lives=9;
                
            
                //SceneManager.LoadScene("SampleScene");
            
        }
}
