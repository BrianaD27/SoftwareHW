using System.ComponentModel;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace ClassLibraryHW1;

public class Class1
{
    public String CheckPassword(String password)
    {
        bool hasUpperCase = false;
        bool hasLowerCase = false;
        bool hasNumber = false;
        bool hasSymbol = false;
        int count = 0;

        if (password.Length < 8 && password.Length != 0)
        {
            return "INCORRECT PASSWORD LENGTH. Passwords must have 8 characters.";
        }

        for (int i = 0; i < password.Length; i++)
        {
            if (char.IsUpper(password[i]) && !hasUpperCase)
            {
                hasUpperCase = true;
                count++;

            }
            else if (char.IsLower(password[i]) && !hasLowerCase)
            {
                hasLowerCase = true;
                count++;

            }
            else if (char.IsDigit(password[i]) && !hasNumber)
            {
                hasNumber = true;
                count++;
            }
            else if ((char.IsSymbol(password[1]) || char.IsPunctuation(password[i])) && !hasSymbol)
            {
                hasSymbol = true;
                count++;
            }

            if (hasUpperCase && hasLowerCase && hasNumber && hasSymbol)
            {
                break;
            }
        }

        switch (count)
        {
            case 0:
                return "INELIGIBLE";
            case 1:
                return "WEAK";
            case 2 or 3:
                return "MEDIUM";
            case 4:
                return "STRONG";
            default:
                return "INELIGIBLE"; 
        }
    }
}
