using UnityEngine;

[CreateAssetMenu(fileName = "ExampleData", menuName = "Example/Data", order = 1)]
public class ExampleData : ScriptableObject
{
    [SerializeField] private string exampleName;
    [SerializeField] private int exampleValue;
    [SerializeField] private Animation exampleAnimation;
    [SerializeField] private AudioSource exampleAudio;

    public string ExampleName => exampleName;
    public int ExampleValue => exampleValue;
    public Animation ExampleAnimation => exampleAnimation;
    public AudioSource ExampleAudio => exampleAudio;
}
