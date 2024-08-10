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

        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valorCurso;


        public CursoTest()
        {
            _nome = "Informativa básica";
            _cargaHoraria = 80;
            _publicoAlvo = PublicoAlvo.Estudante;
            _valorCurso = 349.50;

        }

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
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                ValorCurso = _valorCurso
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


            Assert.Throws<ArgumentException>(() =>
            new Curso(nomeInvalido, _cargaHoraria,
            _publicoAlvo, _valorCurso)).ComMensagem("Nome invalido.");

        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1Hora(double CargaHorariaInvalida)
        {

            Assert.Throws<ArgumentException>(() =>
            new Curso(_nome, CargaHorariaInvalida,
            _publicoAlvo, _valorCurso)).ComMensagem("Carga horaria invalida.");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerValorMenorQue1(double ValorCursoInvalido)
        {

            Assert.Throws<ArgumentException>(() =>
            new Curso(_nome, _cargaHoraria,
            _publicoAlvo, ValorCursoInvalido)).ComMensagem("Valor invalido.");

        }





    }
}
