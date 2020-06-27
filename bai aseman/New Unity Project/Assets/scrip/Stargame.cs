using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stargame : MonoBehaviour
{
    public GameObject particleSystem;
    public static bool isGameOver=false;
    private Animator player;
    public float speed=5f;
    public float jumpHeigh=5f;
    int score = 0;
    public Text textdiem;
    public GameObject source;
    public AudioSource audio;
   // private isGameOver=false;
    // Start is called before the first frame update
    void Start()
    {
        
        player=GetComponent<Animator>();
               isGameOver=false;
        textdiem = GameObject.Find ("txtTextdiem").GetComponent<Text>();
   audio=source.GetComponent<AudioSource>();
    }
  void OnCollisionEnter2D(Collision2D coll){
      
    if(coll.gameObject.tag == "Tien"){
        score++;
        Destroy(coll.gameObject);
        
        textdiem.text = "Diem :" + score.ToString();
          audio.Play();
        GameObject obj = Instantiate(particleSystem);
        Destroy(obj,3);
        
    }
}
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.RightArrow)){
  player.SetBool("isruning",true);
  player.SetBool("isdia",false);
    gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);

    if(gameObject.transform.localScale. x < 0){
    gameObject.transform.localScale=
    new Vector3(gameObject.transform.localScale.x * - 1,
    gameObject.transform.localScale.y
    ,gameObject.transform.localScale.z);
   }
       }
       else if (Input.GetKey(KeyCode.LeftArrow)){
  player.SetBool("isruning",true);
  player.SetBool("isdia",false);
  gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);

    if(gameObject.transform.localScale.x > 0){
    gameObject.transform.localScale=
    new Vector3(gameObject.transform.localScale.x * -1,
    gameObject.transform.localScale.y
    ,gameObject.transform.localScale.z);
}
       }
       else if(Input.GetKey(KeyCode.Space)){
            player.SetBool("isruning",true);
  player.SetBool("isdia",false);
           gameObject.GetComponent<Rigidbody2D>().velocity=
           new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,jumpHeigh);

       }
       else
       {
          player.SetBool("isruning",true);
  player.SetBool("isdia",false);
       }
    }
}
