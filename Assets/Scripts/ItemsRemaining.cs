using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsRemaining : MonoBehaviour {

    public Color FullColor;
    public Color MidColor;
    public Color EmptyColor;

    public Image Fill;

    private int maxValue;
    private int currentValue;

    public int MaxValue {
        get { return maxValue; }
        set {
            maxValue = value;
            UpdateBar();
        }
    }

    public int CurrentValue {
        get { return currentValue;}
        set {
            currentValue = value;
            UpdateBar();
        }
    }

    private Slider bar;

	// Use this for initialization
	void Start () {
	    
	}

    private void UpdateBar () {
        if (bar == null) {
            bar = GetComponent<Slider>();
        }
        bar.maxValue = maxValue;
        bar.value = currentValue;
        float ratio = ((float) currentValue) / maxValue;
        Color fillColor;
        if (ratio > 0.5f) {
            ratio -= 0.5f;
            fillColor = Color.Lerp(MidColor, FullColor, ratio);
        }
        else {
            fillColor = Color.Lerp(EmptyColor, MidColor, ratio);
        }
        Fill.color = fillColor;
    }

    
}
