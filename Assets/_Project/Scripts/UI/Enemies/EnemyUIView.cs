using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.Enemies
{
    public class EnemyUIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _hpText;
        [SerializeField] private TMP_Text _maxHpText;
        [SerializeField] private Slider _hpSlider;

        public void SetName(string sName)
        {
            _nameText.text = sName;
        }

        public void SetHp(int hp)
        {
            _hpSlider.value = hp;
            _hpText.text = hp.ToString();
        }

        public void SetMaxHp(int maxHp)
        {
            _maxHpText.text = maxHp.ToString();
        }
    }
}