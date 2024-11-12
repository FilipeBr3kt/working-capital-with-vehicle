using System.Text.RegularExpressions;

namespace ApiGiroComVeiculo.Api.Common.Utils;

public static class Validators
{
    public static bool IsValidCNPJ(string cnpj)
    {
        int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int result;
        int rest;
        string digit;
        string tempCnpj;
        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        if (cnpj.Length != 14)
            return false;
        tempCnpj = cnpj.Substring(0, 12);
        result = 0;
        for (int i = 0; i < 12; i++)
            result += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
        rest = (result % 11);
        if (rest < 2)
            rest = 0;
        else
            rest = 11 - rest;
        digit = rest.ToString();
        tempCnpj = tempCnpj + digit;
        result = 0;
        for (int i = 0; i < 13; i++)
            result += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
        rest = (result % 11);
        if (rest < 2)
            rest = 0;
        else
            rest = 11 - rest;
        digit = digit + rest.ToString();
        return cnpj.EndsWith(digit);
    }

    public static bool IsValidCPF(string cpf)
    {
        int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digit;
        int sum;
        int remainder;
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;
        tempCpf = cpf.Substring(0, 9);
        sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
        remainder = sum % 11;
        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;
        digit = remainder.ToString();
        tempCpf = tempCpf + digit;
        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
        remainder = sum % 11;
        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;
        digit = digit + remainder.ToString();
        return cpf.EndsWith(digit);
    }

    public static bool IsValidDDD(int ddd)
    {
        return ddd >= 11 && ddd <= 99;
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        phoneNumber = phoneNumber.Trim();
        if (phoneNumber.Length < 8 || phoneNumber.Length > 9 || !phoneNumber.All(char.IsDigit))
            return false;
        if (phoneNumber.Length == 9 && phoneNumber[0] != '9')
            return false;

        return true;
    }

    public static bool IsValidPlate(string plate)
    {
        plate = plate.Trim().ToUpper();

        var oldFormatPattern = @"^[A-Z]{3}-?[0-9]{4}$";
        var newFormatPattern = @"^[A-Z]{3}[0-9][A-Z][0-9]{2}$";

        return Regex.IsMatch(plate, oldFormatPattern) || Regex.IsMatch(plate, newFormatPattern);
    }


}
