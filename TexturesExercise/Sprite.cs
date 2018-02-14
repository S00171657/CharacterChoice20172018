using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TexturesExercise
{
    class Sprite
    {
        Texture2D _tx;
        protected Rectangle _bounds;
        string _CharacterName;
        bool _selected = false;
        
        public string CharacterName
        {
            get
            {
                return _CharacterName;
            }

            set
            {
                _CharacterName = value;
            }
        }
        public bool Selected
        {
            get
            {
                return _selected;
            }

            set
            {
                _selected = value;
            }
        }

        public Texture2D Tx
        {
            get
            {
                return _tx;
            }

            set
            {
                _tx = value;
            }
        }

        public Sprite(Texture2D tx, Rectangle bound)
        {
            _tx = tx;
            _bounds = bound;
        }

        public virtual void Update()
        {
            if(InputEngine.IsMouseLeftClick() && _bounds.Contains(InputEngine.MousePosition))
                {
                _selected = true;
                }
        }

        public void Draw(SpriteBatch sp)
        {
            sp.Draw(_tx, _bounds, Color.White);
        }
    }
}
