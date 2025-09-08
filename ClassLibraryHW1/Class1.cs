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
    /// <param name="password">The entered string that will be evaluated as a password</param>
    public String CheckPassword(String password)
    {
        /// <param name="hasUpperCase">Tracks if an uppercase letter exists in the password </param>
        /// <param name="hasLowerCase">Tracks if a lowercase letter exists in the password </param>
        /// <param name="hasNumber">Tracks if a number exists in the password </param>
        /// <param name="hasSymbol">Tracks if a symbol exists in the password </param>
        /// <param name="count">Tracks the number of cases that were passed</param>
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

    /// <summary>Generates 4 unique UUID Strings</summary>
    public String UUIDGenerator()
    {
        string finalUUID = "";
        for (int i = 0; i < 4; i++)
        {
            string uuid = Guid.NewGuid().ToString();
            finalUUID += uuid + Environment.NewLine;
        }
        return finalUUID;
    }
}
