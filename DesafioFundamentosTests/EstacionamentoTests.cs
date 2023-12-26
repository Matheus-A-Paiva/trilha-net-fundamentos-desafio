using DesafioFundamentos.Models;
using Microsoft.VisualStudio.TestPlatform.Utilities;
namespace DesafioFundamentosTests;

public class EstacionamentoTests
{
    private Estacionamento _estacionamento = new Estacionamento(precoInicial: 5, precoPorHora: 2);
    [Fact]
    public void DeveAdicionarVeiculoERetornarVerdadeiro()
    {   
        //Arrange
        string veiculo = "ABC-1234";
        //Act
        bool resultado = _estacionamento.AdicionarVeiculo(veiculo);

        //Assert
        Assert.True(resultado);
        
    }
    [Fact]
    public void NaoDeveRemoverVeiculo()
    {
        //Arrange
        string placa = "XYZ-1234";

        //Act
        bool resultado = _estacionamento.RemoverVeiculo(placa);
        
        //Assert
        Assert.False(resultado);
    }
    [Fact]
    public void DeveListarVeiculosCorretamenteQuandoExistemVeiculos()
    {
        //Arrange
        _estacionamento.AdicionarVeiculo("ABC-1234");
        _estacionamento.AdicionarVeiculo("XYZ-4321");

        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        //Act
        _estacionamento.ListarVeiculos();
        var resultado = consoleOutput.ToString().Trim();

        //Assert
        Assert.Contains("ABC-1234", resultado);
        Assert.Contains("XYZ-4321", resultado);
    }
    [Fact]
    public void DeveEnviarMensagemQuandoNaoExistemVeiculosEmListarVeiculos()
    {
        //Arrange
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        //Act
        _estacionamento.ListarVeiculos();
        var resultado = consoleOutput.ToString().Trim();

        //Assert
        Assert.Contains("Não há veículos estacionados.", resultado);
    }
}