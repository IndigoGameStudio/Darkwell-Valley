using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSettings", menuName = "ScriptableObject/Settings")]
public class Settings : ScriptableObject
{
    [Header("Spremanje glasnoće glazbe.")]
    [SerializeField]
    private float volume;
    public float Volume { get { return volume; } set { volume = value; } }

    [Header("Spremanje jačine pomicanja miša.")]
    [SerializeField]
    private float sensivity;
    public float Sensivity { get { return sensivity; } set { sensivity = value; } }


    [Header("Sprema zadnju postavljenu jačinu grafike.")]
    [SerializeField]
    private int quailty;
    public int Quality { get { return quailty; } set { quailty = value; } }


    [Header("Sprema odabranu rezoluciju ekrana.")]
    [SerializeField]
    private int resolution;
    public int Resolution { get { return resolution; } set { resolution = value; } }

    [Header("Sprema stanje ekrana.")]
    [SerializeField]
    private bool fullscreen;
    public bool FullScreen { get { return fullscreen; } set { fullscreen = value; } }

}
