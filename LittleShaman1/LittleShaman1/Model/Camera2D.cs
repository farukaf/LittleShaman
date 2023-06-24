using LittleShaman1.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.UI.Xaml.Media; não utilizar (possui classe matrix que confunde com o do xna.framework

namespace LittleShaman1.Model
{
    public class Camera2D
    {
        //matriz de transformação do mundo
        protected Matrix transform;
        //posição da camera
        protected Vector2 position;
        //camera
        protected Viewport viewport;

        //limite da posilçao da camera.
        public int limitX, limitY;

        //ctrl+r, ctrl+e + enter + enter
        public Matrix Transform
        {
            get { return transform; }
            set { transform = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Camera2D(Viewport viewport, int limitX, int limitY)
        {
            position = Vector2.Zero;
            this.viewport = viewport;

            this.limitX = limitX;
            this.limitY = limitY;
        }



        public void Update()
        {
            position = Assist.followPosition;

            if (position.X < viewport.Bounds.Width / 2)
                position.X = viewport.Bounds.Width / 2;

            else if (position.X + viewport.Bounds.Width / 2 > limitX)
                position.X = limitX - viewport.Bounds.Width / 2;

            if (position.Y < viewport.Bounds.Height / 2)
                position.Y = viewport.Bounds.Height / 2;

            else if (position.Y + viewport.Bounds.Height / 2 > limitY)
                position.Y = limitY - viewport.Bounds.Height / 2;


            transform = Matrix.CreateTranslation(

                new Vector3(
                    -position.X + viewport.Bounds.Width * 0.5f,
                    -position.Y + viewport.Bounds.Height * 0.5f, 0
                    ));

            Assist.camPosition = new Vector3(
                      -position.X + viewport.Bounds.Width * 0.5f,
                    -position.Y + viewport.Bounds.Height * 0.5f, 0
                    );
        }





    }
}
