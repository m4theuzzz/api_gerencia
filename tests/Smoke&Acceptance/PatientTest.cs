using Xunit;
using Api.Models;
using System;

public class PatientTest
{
    [Fact]
    public void Test_Patient_Creation()
    {
        // Arrange
        var patient = new Patient(
            1,
            "Test",
            "Patient",
            'M',
            DateTime.Now.AddYears(-30),
            170,
            70,
            "12345678901"
        );

        // Assert
        Assert.Equal("Test", patient.Nome);
        Assert.Equal("Patient", patient.Sobrenome);
        Assert.Equal('M', patient.Sexo);
        Assert.Equal(30, patient.CalcularIdade());
        Assert.Equal(170, patient.Altura);
        Assert.Equal(70, patient.Peso);
        Assert.Equal("12345678901", patient.CPF);
    }

    [Fact]
    public void Test_Patient_Methods()
    {
        // Arrange
        var patient = new Patient(
            1,
            "Test",
            "Patient",
            'M',
            DateTime.Now.AddYears(-30),
            170,
            70,
            "12345678901"
        );

        // Act
        var imc = patient.CalcularIMC();
        var idade = patient.CalcularIdade();
        var cpfValido = patient.ValidarCPF();
        var situacaoImc = patient.obterSituacaoIMC();

        // Assert
        Assert.True(imc > 0);
        Assert.Equal(30, idade);
        Assert.True(cpfValido);
        Assert.NotNull(situacaoImc);
    }
}
