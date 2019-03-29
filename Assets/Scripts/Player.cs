using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int scoreValue = 0;

    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public bool succesParticle;
    //public ParticleSystem _psystem;

    public Color colorCyan;
    public Color colorMagenta;
    public Color colorYellow;
    public Color colorWhite;

    private int score;


    private void Start()
    {
        SetRandomColor();
        succesParticle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag.Contains("Change"))
        {
            Debug.Log("Change event detected");
            if (col.tag == "ChangeCyan")
            {
                sr.color = colorCyan;
                currentColor = "Cyan"; // test code to fix bug
                Destroy(col.gameObject);
                return;
            }
            else if (col.tag == "ChangeMagenta")
            {
                sr.color = colorMagenta;
                currentColor = "Magenta"; // test code to fix bug
                Destroy(col.gameObject);
                return;
            }
            else if (col.tag == "ChangeYellow")
            {
                sr.color = colorYellow;
                currentColor = "Yellow"; // test code to fix bug
                Destroy(col.gameObject);
                return;
            }
            else if (col.tag == "ChangeWhite")
            {
                sr.color = colorWhite;
                currentColor = "White"; // test code to fix bug
                Destroy(col.gameObject);
                return;
            }
        }
        else
        {
            //Debug.Log("Not a change event");
            if (col.tag == "Unknown")
            {
                Debug.Log("dis not wurking");
            }
            else
            {
                // is de kleur van het deel van de cirkel gelijk aan de kleur
                // van de player
                if (col.tag == currentColor)
                {
                    // wat voor soort cirkel ben ik net doorheen gegaan
                    // de kleine, middel of grote cirkel

                    GameObject parent = col.gameObject.transform.parent.gameObject;
                    Debug.Log("DIT IS RICHARDS CODE De naam van de parent is " + parent.tag);

                    if (parent.tag == "SmallCircleTag")
                    {
                        //Debug.Log("so smol");
                        ScoreScript.scoreValue += 100;
                        succesParticle = true;
                        FindObjectOfType<AudioManager>().Play("succesSound");
                        //_psystem.Play(); // PARTICLE SYSTEM
                        //_psystem = true;
                    }
                    else if (parent.tag == "MediumCircleTag")
                    {
                        //Debug.Log("medium");
                        ScoreScript.scoreValue += 500;
                        FindObjectOfType<AudioManager>().Play("succesSound");
                    }
                    else if (parent.tag == "LargeCircleTag")
                    {
                        //Debug.Log("big ass mo-fo");
                        ScoreScript.scoreValue += 1000;
                        FindObjectOfType<AudioManager>().Play("succesSound");
                    }
                    else
                    {
                        //Debug.Log("WAAROM WERK DIT NOU VERDOMME NIET");
                    }

                    //Debug.Log("Nice one!");
                    Destroy(col.gameObject);
                    //succesParticle = true;
                    //_psystem.Play(); // PARTICLE SYSTEM
                    //ScoreScript.scoreValue += 100;
                }
                else if (sr.color == colorWhite)
                {
                    GameObject parent = col.gameObject.transform.parent.gameObject;

                    if ((parent.tag == "SmallCircleTag") && (col.tag == "White"))
                    {
                        //Debug.Log("so smol");
                        ScoreScript.scoreValue += 100;
                        FindObjectOfType<AudioManager>().Play("succesSound");
                    }
                    else if (parent.tag == "MediumCircleTag")
                    {
                        //Debug.Log("medium");
                        ScoreScript.scoreValue += 200;
                        FindObjectOfType<AudioManager>().Play("succesSound");
                    }
                    else if (parent.tag == "LargeCircleTag")
                    {
                        //Debug.Log("big ass mo-fo");
                        ScoreScript.scoreValue += 300;
                        FindObjectOfType<AudioManager>().Play("succesSound");
                    }
                    else
                    {
                        //Debug.Log("WAAROM WERK DIT NOU VERDOMME NIET");
                    }

                    Debug.Log("White one!");
                    Destroy(col.gameObject);
                    FindObjectOfType<AudioManager>().Play("failSound");

                }
                else if (col.name.Contains("End"))
                {
                    Debug.Log("GAME OVER! " + col.tag);
                    //FindObjectOfType<AudioManager>().Play("failSound");
                }
                else
                {
                    Debug.Log("GAME OVER! " + col.tag);
                    FindObjectOfType<AudioManager>().Play("failSound");
                }
            }
        }
    }

    void SetRandomColor ()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 2:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 3:
                currentColor = "White";
                sr.color = colorWhite;
                break;
        }
    }

}
