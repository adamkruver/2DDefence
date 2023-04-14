using System;
using UnityEngine;

namespace Assets.Sources.Settings
{
    public class InputSetting
    {
        public InputSetting()
        {
            KeyCodes = new Func<KeyCode>[]
            {
                EnableInput,
                DisableInput,
                SelectNextPlayer,
                SelectPrevPlayer,
                Exit,
                PlayerMoveDown,
                PlayerMoveLeft,
                PlayerMoveRight,
                PlayerMoveUp,
            };
        }

        public Func<KeyCode> EnableInput { get; } = () => KeyCode.F1;
        public Func<KeyCode> DisableInput { get; } = () => KeyCode.F2;
        public Func<KeyCode> SelectNextPlayer { get; } = () => KeyCode.F3;
        public Func<KeyCode> SelectPrevPlayer { get; } = () => KeyCode.F4;
        public Func<KeyCode> Exit { get; } = () => KeyCode.F12;
        public Func<KeyCode> PlayerMoveLeft { get; } = () => KeyCode.LeftArrow;
        public Func<KeyCode> PlayerMoveRight { get; } = () => KeyCode.RightArrow;
        public Func<KeyCode> PlayerMoveUp { get; } = () => KeyCode.UpArrow;
        public Func<KeyCode> PlayerMoveDown { get; } = () => KeyCode.DownArrow;

        public Func<KeyCode>[] KeyCodes { get; }
    }
}