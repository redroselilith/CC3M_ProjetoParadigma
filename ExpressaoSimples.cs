using System;

namespace Calculadora
{
    public class ExpressaoSimples
    {
        private readonly double operando1;
        private readonly string operador;
        private readonly double operando2;
        private readonly double resultado;

        public ExpressaoSimples(double operando1, string operador, double operando2)
        {
            this.operando1 = operando1;
            this.operador = operador;
            this.operando2 = operando2;

            resultado = operador switch
            {
                "+" => operando1 + operando2,
                "-" => operando1 - operando2,
                "*" => operando1 * operando2,
                "/" => operando1 / operando2,
                "^" => Math.Pow(operando1, operando2),
                _ => throw new ArgumentException($"Operador desconhecido: {operador}")
            };
        }

        public double Operando1 => operando1;
        public string Operador => operador;
        public double Operando2 => operando2;
        public double Resultado => resultado;
    }
}