using System;
using UnityEngine;

namespace _Project.UI.Enemies
{
    [Serializable]
    public class EnemyView
    {
        [SerializeField] private EnemySlotView _slotView;
        [SerializeField] private EnemyUIView _uiView;
        
        public EnemySlotView Slot => _slotView;
        public EnemyUIView UI => _uiView;
    }
}