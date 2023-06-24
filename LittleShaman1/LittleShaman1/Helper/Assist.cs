using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleShaman1.Helper
{
    public static class Assist
    {

        /// <summary>
        /// Resolução da Tela;
        /// </summary>
        public static Vector2 Resolution = new Vector2(1280, 720);

        /// <summary>
        /// Plataform Size;
        /// </summary>
        public static Vector2 PlataformRectangleSize = new Vector2(70, 20);

        /// <summary>
        /// Camera segue essa variavel. Meio da tela como padrão
        /// </summary>
        public static Vector2 followPosition = new Vector2(Resolution.X / 2, Resolution.Y / 2);

        /// <summary>
        /// Atualizada no Camera2d subtraia a posição do mouse para descobrir sua posição no mundo virtual
        /// </summary>
        public static Vector3 camPosition = new Vector3(0, 0, 0);

        /// <summary>
        /// Modo Controle do personagem
        /// </summary>
        public static bool ControlState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static long Fatorial(int i)
        {
            if (i <= 1)
                return 1;
            else return i * Fatorial(i - 1);
        }


        public static long SomaFat(int i)
        {
            if (i <= 1)
                return 1;
            else return i + Fatorial(i - 1);
        }


    }
}
