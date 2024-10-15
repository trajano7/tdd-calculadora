using ProjetoCalculadora;

namespace TestCalculadora;

public class CalculadoraTests
{
    private readonly Calculadora calc;

    public CalculadoraTests()
    {
        calc = new Calculadora();
    }

    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void DeveReceberDoisValoresERetornarASoma(int num1, int num2, int resultado)
    {
        int resultadoCalculadora = calc.Somar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (1, 2, -1)]
    [InlineData (21, 7, 14)]
    public void DeveReceberDoisValoresERetornarASubtracao(int num1, int num2, int resultado)
    {
        int resultadoCalculadora = calc.Subtrair(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (1, 2, 2)]
    [InlineData (4, 5, 20)]
    public void DeveReceberDoisValoresERetornarAMultiplicao(int num1, int num2, int resultado)
    {
        int resultadoCalculadora = calc.Multiplicar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (6, 2, 3)]
    [InlineData (20, 5, 4)]
    public void DeveReceberDoisValoresERetornarADivisao(int num1, int num2, int resultado)
    {
        int resultadoCalculadora = calc.Dividir(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero() {
        Assert.Throws<DivideByZeroException>(() => calc.Dividir(10, 0));
    }

    [Fact]
    public void TestarHistorico() {
        calc.Somar(1,2);
        calc.Somar(3,6);
        calc.Somar(9,7);
        calc.Somar(5,5);
        var historico = calc.Historico();

        Assert.NotEmpty(historico);
        Assert.Equal(3, historico.Count);
    }
}