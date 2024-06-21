using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMHYST.Resources.Values
{
    class AppThemeColors
    {
        /* 
        Estructura del Array de Colores:

        Modo Oscuro
        1. Color de Fondo (Oscuro)
        2. Color de Fondo (SemiOscuro)
        3. Color de Contraste (Texto de Color)
        4. Color de Texto (Blanco)
         
         */

        public Color[] GetColorArray(string theme = "default")
        {
            Color[] selectedThemeColors = [
                Color.FromArgb("#000000"),
                Color.FromArgb("#000000"),
                Color.FromArgb("#000000"),
                Color.FromArgb("#000000")
            ];



            switch (theme)
            {
                case "default":
                    selectedThemeColors = [
                        Color.FromArgb("#000000"),
                        Color.FromArgb("#101010"),
                        Color.FromArgb("#D090F0"),
                        Color.FromArgb("#FFFFFF")
                    ];
                    break;
            }

            return selectedThemeColors;
        }
    }
}
