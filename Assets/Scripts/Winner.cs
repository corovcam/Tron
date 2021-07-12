using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
    public Text textWinner;

    private void Awake()
    {
        textWinner.text = GameOptions.Winner + " wins!";
    }
}
