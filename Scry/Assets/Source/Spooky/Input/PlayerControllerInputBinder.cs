using InControl;
using UnityEngine;

namespace Spooky.Input
{
    public class PlayerControllerInputBinder : MonoBehaviour
    {
        internal PlayerControllerInputActions actions;
        private const float ANALOG_STICK_THRESHOLD = 0.35f;

        void Start()
        {
            actions = new PlayerControllerInputActions();

            //Left
            actions.Left.AddDefaultBinding(Key.LeftArrow);
            actions.Left.AddDefaultBinding(InputControlType.DPadLeft);
            actions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
            actions.Left.StateThreshold = ANALOG_STICK_THRESHOLD;
            
            //Right
            actions.Right.AddDefaultBinding(Key.RightArrow);
            actions.Right.AddDefaultBinding(InputControlType.DPadRight);
            actions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
            actions.Right.StateThreshold = ANALOG_STICK_THRESHOLD;

            //Up
            actions.Up.AddDefaultBinding(Key.UpArrow);
            actions.Up.AddDefaultBinding(InputControlType.DPadUp);
            actions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
            actions.Up.StateThreshold = ANALOG_STICK_THRESHOLD;
            
            //Down
            actions.Down.AddDefaultBinding(Key.DownArrow);
            actions.Down.AddDefaultBinding(InputControlType.DPadDown);
            actions.Down.AddDefaultBinding(InputControlType.LeftStickDown);
            actions.Down.StateThreshold = ANALOG_STICK_THRESHOLD;

            //Jump
            actions.Jump.AddDefaultBinding(Key.Space);
            actions.Jump.AddDefaultBinding(InputControlType.Action1);
            actions.Jump.AddDefaultBinding(InputControlType.Action2);

            //Shoot 1
            actions.Shoot_0.AddDefaultBinding(Key.S);
            actions.Shoot_0.AddDefaultBinding(InputControlType.Action3);
            //actions.Shoot.AddDefaultBinding(InputControlType.Action4);

            //Shoot 1
            actions.Shoot_1.AddDefaultBinding(Key.S);
            actions.Shoot_1.AddDefaultBinding(InputControlType.Action4);
            //actions.Shoot.AddDefaultBinding(InputControlType.Action4);

            //Anchor
            actions.Anchor.AddDefaultBinding(Key.A);
            actions.Anchor.AddDefaultBinding(InputControlType.LeftBumper);
            actions.Anchor.AddDefaultBinding(InputControlType.RightBumper);

            //Next Weapon
            actions.NextWeapon.AddDefaultBinding(Key.W);
            actions.NextWeapon.AddDefaultBinding(InputControlType.RightTrigger);

            //Previous Weapon
            actions.PrevWeapon.AddDefaultBinding(Key.Q);
            actions.PrevWeapon.AddDefaultBinding(InputControlType.LeftTrigger);

            //Abillity
            actions.Ability.AddDefaultBinding(Key.LeftShift);
            actions.Ability.AddDefaultBinding(InputControlType.Action2);
        }

        private void OnDestroy()
        {
            if (actions!= null)
            {
                actions.Destroy();
            }
        }
    }
}