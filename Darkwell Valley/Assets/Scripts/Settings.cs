using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSettings", menuName = "ScriptableObject/Settings")]
public class Settings : ScriptableObject
{
    [Header("Ovo ti je za smanjit muziku sinko.")]
    [SerializeField]
    private float volume;
    public float Volume { get { return volume; } set { volume = value; } }

    [Header("Ovo ti je za podesiti osjetljivost.")]
    [SerializeField]
    private float sensivity;
    public float Sensivity { get { return sensivity; } set { sensivity = value; } }


    [Header("Ovo ti je za podesiti kvalitetu grafike ako imaš potato računalo.")]
    [SerializeField]
    private int quailty;
    public int Quality { get { return quailty; } set { quailty = value; } }


    [Header("Ovo ti je za podesiti rezoluciju.")]
    [SerializeField]
    private int resolution;
    public int Resolution { get { return resolution; } set { resolution = value; } }

    [Header("Ovo ti je za podesiti puni ekran.")]
    [SerializeField]
    private bool fullscreen;
    public bool FullScreen { get { return fullscreen; } set { fullscreen = value; } }

}
