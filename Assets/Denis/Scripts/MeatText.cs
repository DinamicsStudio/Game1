using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class MeatText : MonoBehaviour
{
    [SerializeField] private MeatMiniGame _meatMiniGame;
    [SerializeField] private TMP_Text _meatText;
    private void OnEnable()
    {
        _meatMiniGame.MeatUpdate += UpdateText;
    }

    private void OnDisable()
    {
        _meatMiniGame.MeatUpdate -= UpdateText;
    }
    private void UpdateText()
    {
        int add = _meatMiniGame.meatCountInThis;
        _meatText.text = Convert.ToString(Convert.ToInt32(_meatText.text) + add);
    }
}
