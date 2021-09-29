using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurveManager : MonoBehaviour
{
    public AnimationCurve Curve1;
    public AnimationCurve Curve2;
    public AnimationCurve Curve3;
    private float timer;
    private float timer2;
    private float timer3;

    public Transform thingToMessWith;

    public void Update()
    {
        timer += Time.deltaTime;
        float animatedValue = Curve1.Evaluate(timer);
        float animatedValue2 = Curve2.Evaluate(timer2);
        float animatedValue3 = Curve3.Evaluate(timer3);


        // Simple scale for example
        thingToMessWith.localScale = new Vector3(animatedValue, animatedValue, animatedValue);

        if (timer >= Curve1.length)
        {
            timer2 += Time.deltaTime;
            thingToMessWith.Rotate(animatedValue2, animatedValue2, animatedValue2);

            if (timer2 >= Curve2.length)
            {
                timer3 += Time.deltaTime;
                thingToMessWith.localScale = new Vector3(animatedValue3, animatedValue3, animatedValue3);
            }
        }
    }

}
