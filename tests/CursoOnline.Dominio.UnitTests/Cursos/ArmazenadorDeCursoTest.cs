using Bogus;
using Bogus.DataSets;
using CursoOnline.Dominio.UnitTests._Builders;
using CursoOnline.Dominio.UnitTests._Utils;
using ExpectedObjects;
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
                //PublicoAlvo = PublicoAlvo.Estudante,
                PublicoAlvo = faker.PickRandom<PublicoAlvo>(),
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

        [Fact]
        public void NaoDeveAdicionarCursoComNomeDeOutroJaExistente()
        {
            Curso cursoJaExistente = CursoBuilder.Novo().ComId(432).ComNome(_cursoDto.Nome).Build();
            _cursoRepositorioMock.Setup(r => r.ObterPeloNome(_cursoDto.Nome)).Returns(cursoJaExistente);

            Assert.Throws<ArgumentException>(() =>
                _armazenadorDeCurso.Armazenar(_cursoDto))
            .ComMensagem("Nome do curso já cadastrado.");
        }

        [Fact]
        public void DeveAlterarDadosDoCursoJaExistente()
        {
            _cursoDto.Id = 123;

            var cursoExistente = CursoBuilder.Novo().Build();
            _cursoRepositorioMock.Setup(r => r.ObterPeloId(_cursoDto.Id)).Returns(cursoExistente);

            _armazenadorDeCurso.Armazenar(_cursoDto);

            //_cursoDto.ToExpectedObject().ShouldEqual(cursoExistente);
            Assert.Equal(_cursoDto.Nome, cursoExistente.Nome);
            Assert.Equal(_cursoDto.Descricao, cursoExistente.Descricao);
            Assert.Equal(_cursoDto.ValorCurso, cursoExistente.ValorCurso);
            Assert.Equal(_cursoDto.CargaHoraria, cursoExistente.CargaHoraria);
        }

        [Fact]
        public void DeveAlterarDadosDoCursoJaExistenteENuncaChamarAdicioanr()
        {
            _cursoDto.Id = 123;

            var cursoExistente = CursoBuilder.Novo().Build();
            _cursoRepositorioMock.Setup(r => r.ObterPeloId(_cursoDto.Id)).Returns(cursoExistente);

            _armazenadorDeCurso.Armazenar(_cursoDto);

            _cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()), Times.Never);
        }


    }
}
