using System;
using static Calculadora.ExpressaoSimples;

namespace Calculadora
{
    public class ExpressaoComplexa : ExpressaoSimples
    {
        public ExpressaoComplexa(ExpressaoSimples expressao1, string operador, ExpressaoSimples expressao2)
            : base(expressao1.Resultado, operador, expressao2.Resultado) { }

        public ExpressaoComplexa(double operando1, string operador, ExpressaoSimples expressao2)
            : base(operando1, operador, expressao2.Resultado) { }

        public ExpressaoComplexa(ExpressaoSimples expressao1, string operador, double operando2)
            : base(expressao1.Resultado, operador, operando2) { }
    }
}
