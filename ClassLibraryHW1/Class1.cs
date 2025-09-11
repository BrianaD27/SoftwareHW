using System.ComponentModel;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibraryHW1;

public class Class1
{
    /// <summary> 
    /// This function rates the strength of a password as 
    /// INELIGIBLE, WEAK, MEDIUM, or STRONG based on these requirements:
    /// 1. Password has a length of greater than 8
    /// 2. Password contains a lowercase letter
    /// 3. Password contains an uppercase letter
    /// 4. Password contains a number
    /// 5. Password contains a symbol
    /// </summary>
    /// <param name="password"> The entered string that will be evaluated as a password </param>
    /// <returns>
    /// Returns a rating of INELIGIBLE, WEAK, MEDIUM, or STRONG based on the number of requirements 
    /// the password passes.
    /// </returns>
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
            case 4 or 5:
                return "STRONG";
            default:
                return "INELIGIBLE";
        }
    }

    /// <summary> Generates a version 4 UUID </summary>
    /// <returns> Returns a version 4 UUID string </returns>
    public String UuidGenerator()
    {
        return Guid.NewGuid().ToString();
    }
}
