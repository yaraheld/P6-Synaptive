using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public KeyCode key = KeyCode.Space; // Which key should trigger the fade?
    public float speedScale = 1f;

    public float timeCounter = 2.0f;
    public Color fadeColor = Color.black;
    // Rather than Lerp or Slerp, we allow adaptability with a configurable curve
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1),
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadedOut = false;


    private float alpha = 0f; //aktuelle Transperenz
    private Texture2D texture;
    private int direction = 0; // 1= fading in / -1= fading out
    private float time = 0f;

    private void Start()
    {
        if (startFadedOut) alpha = 1f; else alpha = 0f;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    private void Update()
    {
        if (timeCounter > 0){
            timeCounter -= Time.deltaTime;}
            
        if (direction == 0  && timeCounter <= 0 ) //nur dann kann man einen Fade erzeugen wenn keiner aktiv ist
        {
            if (alpha >= 1f) // Fully faded out 
            {
                alpha = 1f;
                time = 0f;
                direction = 1;
                timeCounter = 15; //wenn UI/Frage in der Scene stattfindet
                // timeCounter = 3; //wenn UI/Frage in einer anderen Scene stattfindet
            }
            else // Fully faded in 
            {
                alpha = 0f;
                time = 1f;
                direction = -1;
            }
                 
        }
        //  wenn Fahrschullehrer selber entscheiden könnte wann er sekundenschlaf setzt - bei Motion-Sickness oder bei Epilepsie: 
        
        //  if (direction == 0 && Input.GetKeyDown(key)) //nur dann kann man einen Fade erzeugen wenn keiner aktiv ist
        // {
        //     if (alpha >= 1f) // Fully faded out
        //     {
        //         alpha = 1f;
        //         time = 0f;
        //         direction = 1;
        //     }
        //     else // Fully faded in
        //     {
        //         alpha = 0f;
        //         time = 1f;
        //         direction = -1;
        //     }
                 
        // }
    }
    public void OnGUI()
    {
        if (alpha > 0f) { GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);}
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if (alpha <= 0f || alpha >= 1f) direction = 0;
        }
    }
}