using Android.Media;
using System.Runtime.Serialization;

namespace ProjectMHYST.Resources.Values
{
    class AppValidation
    {

        public bool IsUppercaseLetter(char c)
        {
            bool result = false;

            switch (c)
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'Ñ':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    result = true;
                    break;
            }

            return result;
        }

        public bool IsLowercaseLetter(char c)
        {
            bool result = false;

            switch (c)
            {
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'ñ':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                    result = true;
                    break;
            }

            return result;
        }

        public bool IsNumber(char c)
        {
            bool result = false;

            switch (c)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    result = true;
                    break;
            }

            return result;
        }

        public bool ValidateEmail(string email)
        {
            bool hasAtSign = false, endsInDotCom = false;


            //Comprobar si contiene @
            for (int i = 0; i < email.Length; i++)
            {
                if (email.ToCharArray()[i] == '@') hasAtSign = true;
            }

            //Comprobar si acaba en .com
            //El correo más chico posible sería: a@b.com
            if (email.Length > 7)
            {
                if (email.Substring(email.Length-4, 4) == ".com")
                    endsInDotCom = true;
            }

            //Si se cumplen ambos regresa true
            return (hasAtSign && endsInDotCom);
        }

        public string ValidatePassword(string password)
        {
            string message = string.Empty;
            char c;
            bool hasUppercaseLetter = false,
                 hasLowercaseLetter = false,
                 hasNumber = false,
                 hasNoSpaces = true;


            for (int i = 0; i < password.Length; i++)
            {
                c = password.ToCharArray()[i];

                if (IsUppercaseLetter(c)) hasUppercaseLetter = true;
                if (IsLowercaseLetter(c)) hasLowercaseLetter = true;
                if (IsNumber(c)) hasNumber = true;

                if (c == ' ') hasNoSpaces = false;
            }

            if (!hasUppercaseLetter || !hasLowercaseLetter || !hasNumber || !hasNoSpaces)
            {
                message = "La contraseña debe contener:";
                if (!hasUppercaseLetter) message += " una letra mayúscula,";
                if (!hasLowercaseLetter) message += " una letra minúscula,";
                if (!hasNumber) message += " un número,";
                if (!hasNoSpaces) message += " ningún espacio,";

                message = message.Substring(0, message.Length-1) + ".";
            }


            return message;
        }

        public string FormatTelNumber(string raw_tel)
        {
            string formatted_tel = string.Empty;

            for (int i = 0; i < raw_tel.Length; i++)
            {
                if (IsNumber(raw_tel.ToCharArray()[i]))
                {
                    formatted_tel += raw_tel.ToCharArray()[i];
                }
            }

            return formatted_tel;
        }
    }
}
