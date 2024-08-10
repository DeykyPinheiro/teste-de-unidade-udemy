using CursoOnline.Dominio.UnitTests._Utils;
using ExpectedObjects;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.UnitTests.Cursos
{
    public class CursoTest
    {
        //admin, criar, editar curso para que sejam abertar matriculas para ele
        //aceite:
        //criar curso com: nome, carga horaria, publico alvo, valor do curso
        //publico alvo: Estudante, Universitario, Empregado, Empreendedor
        //todos os campos são obrigatorios

        public enum PublicoAlvo
        {
            Estudante,
            Universitario,
            Empregado,
            Empreendedor
        }


        [Fact]
        public void DeveCriarCurso()
        {

            var cursoEsperado = new
            {
                Nome = "Informatica básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorCurso = (double)349.50

            };

            Curso curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria,
                cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso);

            //Objeto esperado
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }


        //testar multiplos parametros invalido
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informatica básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorCurso = (double)349.50

            };

            Assert.Throws<ArgumentException>(() =>
            new Curso(nomeInvalido, cursoEsperado.CargaHoraria,
            cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso)).ComMensagem("Nome invalido.");

        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1Hora(double CargaHorariaInvalida)
        {

            var cursoEsperado = new
            {
                Nome = "Informatica básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorCurso = (double)349.50

            };

            Assert.Throws<ArgumentException>(() =>
            new Curso(cursoEsperado.Nome, CargaHorariaInvalida,
            cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso)).ComMensagem("Carga horaria invalida.");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerValorMenorQue1(double ValorCursoInvalido)
        {

            var cursoEsperado = new
            {
                Nome = "Informatica básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorCurso = (double)349.50

            };

            Assert.Throws<ArgumentException>(() =>
            new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria,
            cursoEsperado.PublicoAlvo, ValorCursoInvalido)).ComMensagem("Valor invalido.");
        }





    }
}
