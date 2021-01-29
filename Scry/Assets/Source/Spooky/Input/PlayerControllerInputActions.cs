using InControl;

namespace Spooky.Input
{
    public class PlayerControllerInputActions : PlayerActionSet
    {
        public PlayerAction Left;
        public PlayerAction Right;
        public PlayerAction Up;
        public PlayerAction Down;

        public PlayerOneAxisAction Move;
        public PlayerTwoAxisAction Aim;

        public PlayerAction Jump;
        public PlayerAction Shoot_0;
        public PlayerAction Shoot_1;
        public PlayerAction Anchor;
        public PlayerAction Duck;

        public PlayerAction NextWeapon;
        public PlayerAction PrevWeapon;

        public PlayerAction Ability;

        public PlayerControllerInputActions()
        {
            Left = CreatePlayerAction("Move Left");
            Right = CreatePlayerAction("Move Right");
            Up = CreatePlayerAction("Look Up");
            Down = CreatePlayerAction("Look Down");
            
            Move = CreateOneAxisPlayerAction(Left, Right);
            Aim = CreateTwoAxisPlayerAction(Left, Right, Down, Up);

            Jump = CreatePlayerAction("Jump");
            Shoot_0 = CreatePlayerAction("Shoot 0");
            Shoot_1 = CreatePlayerAction("Shoot 1");
            Anchor = CreatePlayerAction("Anchor");

            NextWeapon = CreatePlayerAction("Next Weapon");
            PrevWeapon = CreatePlayerAction("Previous Weapon");

            Ability = CreatePlayerAction("Activate Abillity");
        }
    }
}
