using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleShaman1.Model
{
    public class Button : Sprite
    {

        SoundEffect buttonEffect;       





        /// <summary>
        /// Single Key Pressed&Release
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="mouseCopy"></param>
        /// <returns></returns>
        public bool Update(MouseState mouse, MouseState mouseCopy)
        {
            
            if (rect.Contains(mouse.Position) &&
                mouse.LeftButton == ButtonState.Pressed && 
                mouseCopy.LeftButton == ButtonState.Released)
            {
                try
                {
                    buttonEffect.Play();
                }
                catch (Exception)
                {                                        
                }
                return true;
            }
            if (rect.Contains(mouse.Position))
            {
                color = Color.DarkOrange;                
            }
            else
            {
                color = Color.White;
            }

            return false;

        }

        /// <summary>
        /// Just press. Better use the other
        /// Apertar apenas. De preferencia ao outro para botões de menu;
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>

        public bool Update(MouseState mouse)
        {

            if (rect.Contains(mouse.Position) &&
                mouse.LeftButton == ButtonState.Pressed)
            {
                try
                {
                    buttonEffect.Play();
                }
                catch (Exception)
                {
                }
                return true;
            }
            if (rect.Contains(mouse.Position))
            {
                color = Color.DarkOrange;
            }
            else
            {
                color = Color.White;
            }

            return false;

        }

        /// <summary>
        /// Single Key Release&Pressed
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="mouseCopy"></param>
        /// <returns></returns>
        public bool UpdateSKRelease(MouseState mouse, MouseState mouseCopy)
        {

            if (rect.Contains(mouse.Position) &&
                mouse.LeftButton == ButtonState.Released &&
                mouseCopy.LeftButton == ButtonState.Pressed)
            {
                try
                {
                    buttonEffect.Play();
                }
                catch (Exception)
                {
                }
                return true;
            }
            if (rect.Contains(mouse.Position))
            {
                color = Color.DarkOrange;
            }
            else
            {
                color = Color.White;
            }

            return false;

        }



    }
}
