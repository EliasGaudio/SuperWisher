using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Wisher : MonoBehaviour
{
    float h;
    float v;
    public float speed = 3;
    Vector3 moveDirection;
    [SerializeField]Transform mira;
    [SerializeField]Camera camara;
    Vector2 direccionMira;
    [SerializeField]Transform bala;
    bool cargaArma = true;
    float velocidadDisparo;
    [SerializeField]float tiempoInvulnerabilidad = 3;
    int vidaWisher;
    [SerializeField]int balasExtra = 0;
    bool superDisparoCargado;
    [SerializeField]bool invulnerable = false;
    [SerializeField] Animator anim; 
    [SerializeField] SpriteRenderer spriteRenderer; 
    [SerializeField] float rateBlinkeo = 1;
    CameraController camController;
    [SerializeField]AudioClip powerUpSonido;
    [SerializeField]AudioClip damage;
    [SerializeField]AudioSource audioSourceWisher;


    public int VidaWisher {
        get => vidaWisher;
        set{
            vidaWisher = value;
            UIManager.Instance.UpdateUIVida(vidaWisher);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        superDisparoCargado = GameManager.Instance.superDisparoCargadoGameManager;
        vidaWisher = GameManager.Instance.vidaWisherGameManager;
        velocidadDisparo = GameManager.Instance.velocidadDisparoGameManager;
        balasExtra = GameManager.Instance.balasExtraGameManager;
        audioSourceWisher = GetComponent<AudioSource>();
        //s.source.clip = s.clip;
        //s.source.volume = s.volume;
        //s.source.pitch = s.pitch;
        
        UIManager.Instance.UpdateUIVida(vidaWisher);
        UIManager.Instance.UpdateUICadencia(velocidadDisparo);
        UIManager.Instance.UpdateUIBalas(superDisparoCargado);
        camController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.superDisparoCargadoGameManager = superDisparoCargado;
        GameManager.Instance.vidaWisherGameManager = vidaWisher;
        GameManager.Instance.velocidadDisparoGameManager = velocidadDisparo;
        GameManager.Instance.balasExtraGameManager = balasExtra;
        //Movimiento
        h = Input.GetAxis("Horizontal");    
        v = Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;
        transform.position += moveDirection * speed * Time.deltaTime;

        
    
        //Mira
        direccionMira = camara.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mira.position = (Vector3)direccionMira.normalized + transform.position;

        //Bala
        if (Input.GetMouseButton(0) && cargaArma && !PauseController.gameIsPaused){
            cargaArma = false;
            
            float angle = Mathf.Atan2(direccionMira.y, direccionMira.x) * Mathf.Rad2Deg;
            Quaternion rotacion = Quaternion.AngleAxis(angle, Vector3.forward);
            Transform clonBala = Instantiate(bala, transform.position, rotacion);
            for (var balasExtraa = balasExtra; balasExtraa > 0; balasExtraa--)
            {
                int dispersor = 1;
                if (balasExtraa % 2 == 0){
                    dispersor = -1;
                }
                Quaternion rotacion2 = Quaternion.AngleAxis(angle + 10 * balasExtraa * dispersor, Vector3.forward);
                Transform clonBala2 = Instantiate(bala, transform.position, rotacion2);
                //Quaternion rotacion3 = Quaternion.AngleAxis(angle - 15 * balasExtraa, Vector3.forward);
                //Transform clonBala3 = Instantiate(bala, transform.position, rotacion3);
                if (superDisparoCargado)
                {
                    clonBala2.GetComponent<Bala>().superDisparoCargadoBala = true;
                    //clonBala3.GetComponent<Bala>().superDisparoCargadoBala = true;
                }
            }
            if (superDisparoCargado)
            {
                clonBala.GetComponent<Bala>().superDisparoCargadoBala = true;
            }
            StartCoroutine(Recargar());
        }

        anim.SetFloat("Speed", moveDirection.magnitude);
        /*if (mira.position.x > transform.position.x)
        {
            spriteRenderer.FlipX = true;
        }
        else if (mira.position.x < transform.position.x)
        {
            spriteRenderer.FlipX = false;        
        }*/
        spriteRenderer.flipX = mira.position.x > transform.position.x;
        
    }

    IEnumerator Recargar(){
        yield return new WaitForSeconds(1/velocidadDisparo);
        cargaArma = true;
    }

    IEnumerator Invulnerabilidad(){
        StartCoroutine(Blinkear());
        yield return new WaitForSeconds(tiempoInvulnerabilidad);
        invulnerable = false;
    }

    IEnumerator Blinkear(){
        int t = 10;
        while (t > 0)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(t * rateBlinkeo);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(t * rateBlinkeo);
            t--;
        }
    }

    public void RecibirDamageWisher(){
        if (!invulnerable)
        {
            audioSourceWisher.clip = damage;
            audioSourceWisher.Play();
            camController.Shake();
            VidaWisher--;
            invulnerable = true;
            StartCoroutine(Invulnerabilidad());    
        }
        
        if (VidaWisher == 0){
            GameManager.Instance.derrotaBool = true;
            UIManager.Instance.MostrarDerrota();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("PowerUp")){
            audioSourceWisher.clip = powerUpSonido;
            audioSourceWisher.Play();
            switch (collision.GetComponent<PowerUp>().powerUpType)
            {
                case PowerUp.PowerUpType.SuperCadenciaDeFuego:
                    velocidadDisparo++;
                    UIManager.Instance.UpdateUICadencia(velocidadDisparo);
        
                    break;
                case PowerUp.PowerUpType.SuperPoderDeDisparo:
                    superDisparoCargado = true;
                    UIManager.Instance.UpdateUIBalas(superDisparoCargado);
                    break;

                case PowerUp.PowerUpType.SuperCantidadDeBalas:
                    balasExtra++;
                    break;
            }
            Destroy(collision.gameObject, 0.1f);
        }
        if (collision.CompareTag("Cofre")){
            if (!collision.GetComponent<Cofre>().abierto){
                collision.GetComponent<Cofre>().abrirCofre(gameObject.transform);
            }
        }

        if (collision.CompareTag("CheckPoint"))
        {
            audioSourceWisher.clip = powerUpSonido;
            audioSourceWisher.Play();
            
        }
    }
}
