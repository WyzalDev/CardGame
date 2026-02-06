using TMPro;
using UnityEngine;

namespace _Project.UI.Enemies
{
    public class EnemySlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetTitle(string title)
        {
            _titleText.text = title;
        }

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}