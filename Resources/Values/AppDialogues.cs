using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMHYST.Resources.Values
{
    class AppDialogues
    {
        public string[] GetDialogues(string dialogue_id = "none")
        {
            string[] dialogues = [
                "No Dialogues Found ):"
                ];

            switch (dialogue_id)
            {
                case "welcome":
                    dialogues = [
                    "—¡Has llegado! Me temo que tienes mucho por aprender, ¿o no?",
                    "*Suspiro*",
                    "—¿Sabes como usar la interfaz?",
                    "—Se supone que debería ser muy intuitiva y todo, pero con MAUI, la más mínima animación tarda dos horas en mostrarse.",
                    "—El simple hecho de que pueda hablar ahora mismo sin trabarme es un milagro...",
                    "—Pero bueno, en esencia, todo lo importante se encuentra en la barra lateral.",
                    "—En la parte de arriba está tu foto de perfil, si clickeas encima puedes cambiarla.",
                    "—Además, en ese menú, también puedes cambiar la paleta de colores, y otras cosas.",
                    "—Abajo de eso están las asignaturas, si clickeas en el ícono verás una lista de temas.",
                    "—Cuando veas la lista de temas, y clickes en uno de ellos, irás a un solucionador.",
                    "—Y ahí mismo intentaremos, LOS DOS, resolver el problema, ¿Ok?",
                    "—Eso es todo, puedes irte."
                    ];
                    break;

                case "event-petted":
                    dialogues = [
                    "—Acabas de..?",
                    "—¡No me toques! Eso es de mala educación, ¿Te gustaría que yo te tocara de la nada?",
                    "—¿Estás sordo? Para de una vez."
                    ];
                    break;
            }

            return dialogues;
        }
    }
}