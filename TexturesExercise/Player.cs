using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TexturesExercise
{
    class Player : Sprite
    {
        int _speed = 10;
        public Player(Texture2D tx, Rectangle bound) : base(tx,bound)
        {

        }

        public override void Update()
        {
            if (InputEngine.IsKeyHeld(Keys.W))
                _bounds.Y -= _speed;
            if (InputEngine.IsKeyHeld(Keys.S))
                _bounds.Y += _speed;
            if (InputEngine.IsKeyHeld(Keys.A))
                _bounds.X -= _speed;
            if (InputEngine.IsKeyHeld(Keys.D))
                _bounds.X += _speed;
            // etc
        }
    }
}
