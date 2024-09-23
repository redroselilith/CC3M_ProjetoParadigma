using Calculadora;
using System;
using System.Collections.Generic;
using System.Linq;

public static class Matematica
{
    private static readonly Dictionary<string, int> PRECEDENCIA = new Dictionary<string, int>
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 },
        { "^", 3 }
    };

    public static ExpressaoSimples Parse(string expressao)
    {
        expressao = expressao.Replace(" ", "");

        return AvaliarPosfixa(InfixParaPosfixa(expressao));
    }

    private static List<string> InfixParaPosfixa(string expressao)
    {
        var operadores = new Stack<string>();
        var output = new List<string>();
        var numero = new System.Text.StringBuilder();

        for (int i = 0; i < expressao.Length; i++)
        {
            char c = expressao[i];

            if (char.IsDigit(c) || c == '.')
            {
                // Construindo o número (permitindo ponto decimal)
                numero.Append(c);
            }
            else
            {
                if (numero.Length > 0)
                {
                    output.Add(numero.ToString());
                    numero.Clear();  // Reiniciar o número
                }

                if (c == '(')
                {
                    operadores.Push("(");
                }
                else if (c == ')')
                {
                    while (operadores.Peek() != "(")
                    {
                        output.Add(operadores.Pop());
                    }
                    operadores.Pop(); // Remover o parêntese esquerdo
                }
                else if (IsOperador(c.ToString()))
                {
                    while (operadores.Count > 0 &&
                           PRECEDENCIA.GetValueOrDefault(c.ToString(), 0) <= PRECEDENCIA.GetValueOrDefault(operadores.Peek(), 0))
                    {
                        output.Add(operadores.Pop());
                    }
                    operadores.Push(c.ToString());
                }
            }
        }

        if (numero.Length > 0)
        {
            output.Add(numero.ToString());
        }

        while (operadores.Count > 0)
        {
            output.Add(operadores.Pop());
        }

        return output;
    }

    private static bool IsOperador(string token)
    {
        return PRECEDENCIA.ContainsKey(token);
    }

    private static ExpressaoSimples AvaliarPosfixa(List<string> rpn)
    {
        var pilha = new Stack<ExpressaoSimples>();

        foreach (var token in rpn)
        {
            if (IsOperador(token))
            {
                var exp2 = pilha.Pop();
                var exp1 = pilha.Pop();
                pilha.Push(new ExpressaoComplexa(exp1, token, exp2));
            }
            else
            {
                pilha.Push(new ExpressaoSimples(double.Parse(token), "+", 0));  // Somando 0 para criar a estrutura básica
            }
        }

        return pilha.Pop();
    }
}
