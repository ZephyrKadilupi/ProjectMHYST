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
                case "dark-theme-1":
                    selectedThemeColors = [
                        Color.FromArgb("#301545"),
                        Color.FromArgb("#100515"),
                        Color.FromArgb("#D090F0"),
                        Color.FromArgb("#FFFFFF")
                    ];
                    break;

                case "dark-theme-2":
                    selectedThemeColors = [
                        Color.FromArgb("#451515"),
                        Color.FromArgb("#150505"),
                        Color.FromArgb("#F0A090"),
                        Color.FromArgb("#FFFFFF")
                    ];
                    break;

                case "dark-theme-3":
                    selectedThemeColors = [
                        Color.FromArgb("#450030"),
                        Color.FromArgb("#200010"),
                        Color.FromArgb("#D060C0"),
                        Color.FromArgb("#FFFFFF")
                    ];
                    break;

                case "dark-theme-4":
                    selectedThemeColors = [
                        Color.FromArgb("#453000"),
                        Color.FromArgb("#151000"),
                        Color.FromArgb("#F0D060"),
                        Color.FromArgb("#FFFFFF")
                    ];
                    break;

                case "default-theme":
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
