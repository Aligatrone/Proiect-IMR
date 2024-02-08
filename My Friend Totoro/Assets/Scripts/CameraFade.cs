using UnityEngine;

public class CameraFade : MonoBehaviour
{
    private int shouldFade = 0;
    public float speedScale = 1f;
    public Color fadeColor = Color.black;
    // Rather than Lerp or Slerp, we allow adaptability with a configurable curve
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1),
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadedOut = false;


    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    private void Start()
    {
        ChatTotoro.ChatDone += TriggerFade;
        SwapTime.TransitionDone += ResetFade;
        EndFirstDay.EndDay += TriggerFade;
        EndFirstDay.EndDaySecret += TriggerFade;
        TeleportMainTotoro.EnterDream += ResetFade;
        if (startFadedOut) alpha = 1f; else alpha = 0f;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    void TriggerFade() {
        shouldFade = 1;
    }

    void ResetFade()
    {
        shouldFade = -1;
    }

    private void Update()
    {
        if (direction == 0 && (shouldFade == 1 || shouldFade == -1))
        {
            if (alpha >= 1f) // Fully faded out
            {
                alpha = 1f;
                time = 0f;
                direction = 1;
                shouldFade = 0;
            }
            else // Fully faded in
            {
                alpha = 0f;
                time = 1f;
                direction = -1;
                shouldFade = 0;
            }
        }
        
    }
    public void OnGUI()
    {
        if (alpha > 0f) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
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