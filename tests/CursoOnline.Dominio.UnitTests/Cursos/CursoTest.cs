using ExpectedObjects;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
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

        public enum PublicoAlvo
        {
            Estudante,
            Universitario,
            Empregado,
            Empreendedor
        }
    }
}
