using Bogus;
using Bogus.DataSets;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.UnitTests.Cursos
{
    public class ArmazenadorDeCursoTest
    {

        private readonly CursoDto _cursoDto;

        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;

        private readonly ArmazenadorDeCurso _armazenadorDeCurso;

        public ArmazenadorDeCursoTest()
        {
            Faker faker = new Faker();

            _cursoDto = new CursoDto
            {
                Nome = faker.Commerce.ProductName(),
                CargaHoraria = faker.Random.Double(20, 1000),
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorCurso = faker.Random.Double(20, 1000),
                Descricao = faker.Lorem.Paragraph()
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }


        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDto);

            //cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));
            _cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(curso =>
                curso.Nome == _cursoDto.Nome &&
                curso.CargaHoraria == _cursoDto.CargaHoraria &&
                curso.PublicoAlvo == _cursoDto.PublicoAlvo &&
                curso.ValorCurso == _cursoDto.ValorCurso &&
                curso.Descricao == _cursoDto.Descricao
            )));
        }
    }

    public interface ICursoRepositorio
    {
        Curso Adicionar(Curso data);
    }

    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public Curso Armazenar(CursoDto data)
        {
            var curso = new Curso(data.Nome, data.Descricao, data.CargaHoraria, data.PublicoAlvo, data.ValorCurso);
            var cursoAdicionado = _cursoRepositorio.Adicionar(curso);
            return cursoAdicionado;
        }
    }
}
