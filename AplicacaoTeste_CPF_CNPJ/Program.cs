using Validar_CPF_CNPJ;

var validadorCPF = new Validador();
var validadorCNPJ = new Validador();
//Console.WriteLine($"CPF válido: {validadorCPF.ValidarCPF("88785779016")}");
//Console.WriteLine($"CNPJ válido: {validadorCNPJ.ValidarCNPJ("34474427000143")}");

/*for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"CPF({i}): {GeradorCPF.GerarCPF()}" );
}*/
//Teste CPF
for (int i = 0; i < 100000; i++)
{
    string cpfGerado = GeradorCPF.GerarCPF();
    bool cpfValido = validadorCPF.ValidarCPF(cpfGerado);
    if (!cpfValido)
    {
        Console.WriteLine($"CPF({cpfGerado}) inválido.");
    }
}
Console.WriteLine("CPF's válidos!");
for (int i = 0; i < 100000; i++)
{
    string CNPJGerado = GeradorCNPJ.GerarCNPJ();
    bool CNPJValido = validadorCNPJ.ValidarCNPJ(CNPJGerado);
    if (!CNPJValido)
    {
        Console.WriteLine($"CNPJ({CNPJGerado}) inválido.");
    }
}
Console.WriteLine("CNPJ's válidos!");
/*for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"CNPJ({i}): {GeradorCNPJ.GerarCNPJ()}");
}*/

public class GeradorCPF
{
    public static string GerarCPF()
    {
        Random random = new Random();
        string numeroBase = "";
        for (int i = 1; i <= 9; i++)
            numeroBase += random.Next(10).ToString();

        // Calcula o primeiro dígito verificador
        int soma = 0;
        int[] multiplicadores = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        for (int i = 0; i < 9; i++)
            soma += int.Parse(numeroBase[i].ToString()) * multiplicadores[i];
        int resto = soma % 11;
        int digito = resto < 2 ? 0 : 11 - resto;
        numeroBase += digito;

        // Calcula o segundo dígito verificador
        soma = 0;
        multiplicadores = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        for (int i = 0; i < 10; i++)
            soma += int.Parse(numeroBase[i].ToString()) * multiplicadores[i];
        resto = soma % 11;
        digito = resto < 2 ? 0 : 11 - resto;
        numeroBase += digito;

        return numeroBase;
    }
}
public static class GeradorCNPJ
{
    public static string GerarCNPJ()
    {
        Random random = new Random();
        string numeroBase = "";
        for (int i = 0; i < 12; i++)
            numeroBase += random.Next(10).ToString();

        // Calcula o primeiro dígito verificador
        int soma = 0;
        int[] multiplicadores = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        for (int i = 0; i < 12; i++)
            soma += int.Parse(numeroBase[i].ToString()) * multiplicadores[i];
        int resto = soma % 11;
        int digito = resto < 2 ? 0 : 11 - resto;
        numeroBase += digito;

        // Calcula o segundo dígito verificador
        soma = 0;
        multiplicadores = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        for (int i = 0; i < 13; i++)
            soma += int.Parse(numeroBase[i].ToString()) * multiplicadores[i];
        resto = soma % 11;
        digito = resto < 2 ? 0 : 11 - resto;
        numeroBase += digito;

        return numeroBase;
    }
}