using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBackgroundScript : MonoBehaviour
{
    public int maxStars = 100;
    public int universeSize = 10;
    private ParticleSystem.Particle[] points;
    float timer = 0;
    //ParticleSystemRenderer renderer = GetComponent<ParticleSystemRenderer>();
    // get specific parts of the particle system
    private new ParticleSystem particleSystem;

    private void Create()
    {
        particleSystem = gameObject.GetComponent<ParticleSystem>();

        points = new ParticleSystem.Particle[maxStars];
        /*
        var col = particleSystem.colorOverLifetime;
        col.enabled = true;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        col.color = grad;
        */
        for (int i = 0; i < maxStars; i++)
        {
            points[i].position = Random.insideUnitSphere * universeSize;
            points[i].startSize = Random.Range(0.1f, .2f);
            points[i].startColor = new Color(0f, 0f, 0f, 0f);
            var main = particleSystem.main;
           // main.startLifetime = 3;
           // points[i].remainingLifetime = 3;

        }

        particleSystem = gameObject.GetComponent<ParticleSystem>();


        particleSystem.SetParticles(points, points.Length);

        //particleSystem.Stop();
        //var main = particleSystem.main;
       // main.duration = 10.0f;

      //  particleSystem.Play();


    }

    void Start()
    {
        
        Create();

    }

    void Update()
    {
        timer += Time.deltaTime;
       
            if (timer >= 4)
            {
            for (int i = 0; i < maxStars; i++)
            {
               
                //particleSystem.SetParticles(points, points.Length);
                 points[i].startColor = new Color(1f, 1f, 1f, 1f);
                  particleSystem.SetParticles(points, points.Length - 100);
                timer = 0;
            }
          
            particleSystem.SetParticles(points, points.Length);
        }
        
        // for (int i = 0; i < maxStars; i++)
        // {
        //float timeAlive = particle.startLifetime - particle.lifetime;
        //float timeAlive = particleSystem.startLifetime - particleSystem.remainingLifetime;
        // }


        //Destroy(gameObject.GetComponent<ParticleSystem>());

        // float timeAlive = 0;
        /*for (int i = 0; i < maxStars; i++)
        {
            ParticleSystem.Particle particle = points[i];
            //int count = particleSystem.GetParticles(points);
            particle.remainingLifetime = -1;
            points[i] = particle;
            */
        //timeAlive = points[i].remainingLifetime;
        //Debug.Log(timeAlive);

        // if(timeAlive == 0)
        // {
        //       points[i].remainingLifetime = 0;
        //      Debug.Log("Heya");






    }
}
