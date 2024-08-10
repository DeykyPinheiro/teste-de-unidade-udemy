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



        [Fact]
        public void DeveCriarCurso()
        {

            var cursoEsperado = new
            {
                Nome = "Informatica básica",
                CargaHoraria = (double)80,
                PublicoAlvo = "Estudantes",
                ValorCurso = (double)349.50

            };

            Curso curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria,
                cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso);

            //Objeto esperado
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }
    }
}
