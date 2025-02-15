﻿using Bogus;
using CursoOnline.Dominio.UnitTests._Builders;
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
        //curso deve ter uma descricao

        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valorCurso;
        private readonly string _descricao;


        public CursoTest()
        {
            var faker = new Faker();

            _nome = faker.Commerce.ProductName();
            _cargaHoraria = faker.Random.Int(40, 200);

            _publicoAlvo = faker.PickRandom<PublicoAlvo>();
            _publicoAlvo = PublicoAlvo.Estudante;

            _valorCurso = faker.Random.Double(100, 1000);
            _descricao = faker.Lorem.Paragraph();
        }


        [Fact]
        public void DeveCriarCurso()
        {

            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                ValorCurso = _valorCurso,
                Descricao = _descricao
            };

            Curso curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria,
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
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
            .ComMensagem(Resource.NomeInvalido);

        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1Hora(double CargaHorariaInvalida)
        {

            Assert.Throws<ArgumentException>(() =>
                    CursoBuilder.Novo().ComCargaHoraria(CargaHorariaInvalida).Build()
            ).ComMensagem(Resource.CargaHorariaInvalida);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerValorMenorQue1(double ValorCursoInvalido)
        {

            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComValorCurso(ValorCursoInvalido).Build()
            ).ComMensagem(Resource.valorCursoInvalido);

        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerDescricaoInvalida(string DescicaoInvalida)
        {

            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComDescricao(DescicaoInvalida).Build())
            .ComMensagem(Resource.DescricaoInvalida);

        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarParaNomeInvalido(string nomeInvalido)
        {
            Curso curso = CursoBuilder.Novo().Build();

            Assert.Throws<ArgumentException>(() =>
               curso.AlteraNome(nomeInvalido))
            .ComMensagem(Resource.NomeInvalido);
        }

        [Fact]
        public void DeveAlterarNome()
        {
            var nomeEsperado = _nome;
            Curso curso = CursoBuilder.Novo().Build();

            curso.AlteraNome(nomeEsperado);

            Assert.Equal(nomeEsperado, curso.Nome);

        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarParaDescricaoInvalida(string descricaoInvalida)
        {
            Curso curso = CursoBuilder.Novo().Build();

            Assert.Throws<ArgumentException>(() =>
               curso.AlterarDescricao(descricaoInvalida))
            .ComMensagem(Resource.DescricaoInvalida);
        }

        [Fact]
        public void DeveAlterarNomeDescricaoValida()
        {
            var descricaoEsperada = _descricao;
            Curso curso = CursoBuilder.Novo().Build();

            curso.AlterarDescricao(descricaoEsperada);

            Assert.Equal(descricaoEsperada, curso.Descricao);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveAlterarCursoParaTerCargaHorariaMenorQue1Hora(double CargaHorariaInvalida)
        {

            Curso curso = CursoBuilder.Novo().Build();

            Assert.Throws<ArgumentException>(() =>
               curso.AlterarCargaHoraria(CargaHorariaInvalida))
            .ComMensagem(Resource.CargaHorariaInvalida);

        }


        [Fact]
        public void DeveAlterarCargaHorariaValidaParaCursoExistente()
        {
            var CargaHorariaEsperada = _cargaHoraria;
            Curso curso = CursoBuilder.Novo().Build();

            curso.AlterarCargaHoraria(CargaHorariaEsperada);

            Assert.Equal(CargaHorariaEsperada, curso.CargaHoraria);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveAlterarCursoParaValorMenorQue1(double ValorCursoInvalido)
        {
            Curso curso = CursoBuilder.Novo().Build();

            Assert.Throws<ArgumentException>(() =>
                curso.AlterarValorCurso(ValorCursoInvalido)
            ).ComMensagem(Resource.valorCursoInvalido);

        }

        [Fact]
        public void DeveAlterarValorDoCursoValidaParaCursoExistente()
        {
            var valorDoCursoEsperado = _valorCurso;
            Curso curso = CursoBuilder.Novo().Build();

            curso.AlterarValorCurso(valorDoCursoEsperado);

            Assert.Equal(valorDoCursoEsperado, curso.ValorCurso);
        }

        [Fact]
        public void DeveAlterarPublicoAlvoParaCursoExistente()
        {
            var publicoAlvoEsperado = _publicoAlvo;
            Curso curso = CursoBuilder.Novo().Build();

            curso.AlterarPulicoAlvo(publicoAlvoEsperado);

            Assert.Equal(publicoAlvoEsperado, curso.PublicoAlvo);
        }



    }
}
