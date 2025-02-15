﻿using CursoOnline.Dominio.UnitTests.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CursoOnline.Dominio.UnitTests.Cursos.CursoTest;

namespace CursoOnline.Dominio.UnitTests._Builders
{
    public class CursoBuilder
    {
        private string _nome = "Informatica Basica";
        private double _cargaHoraria = 80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valorCurso = 350.50;
        private string _descricao = "Descrição teste";
        private int _id;

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComValorCurso(double valorCurso)
        {
            _valorCurso = valorCurso;
            return this;
        }

        public CursoBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public Curso Build()
        {
            var curso = new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valorCurso);

            //configurando o id com reflections
            var propertyInfo = curso.GetType().GetProperty("Id");
            propertyInfo.SetValue(curso, Convert.ChangeType(_id, propertyInfo.PropertyType), null);

            return curso;
        }


    }
}
