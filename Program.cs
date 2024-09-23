using Calculadora;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Digite uma expressão matemática: ");
        string expressao = Console.ReadLine();
        ExpressaoSimples resultado = Matematica.Parse(expressao);
        Console.WriteLine(expressao + " = " + resultado.Resultado);
    }
}