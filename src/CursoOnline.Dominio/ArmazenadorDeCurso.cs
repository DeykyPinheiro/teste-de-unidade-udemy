﻿namespace CursoOnline.Dominio
{
    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public Curso Armazenar(CursoDto data)
        {
            Curso cursoSalvo = _cursoRepositorio.ObterPeloNome(data.Nome);
            if (cursoSalvo != null)
            {
                throw new ArgumentException("Nome do curso já cadastrado.");
            }

            var curso = new Curso(data.Nome, data.Descricao, data.CargaHoraria, data.PublicoAlvo, data.ValorCurso);

            if (data.Id > 0)
            {
                curso = _cursoRepositorio.ObterPeloId(data.Id);
                curso.AlteraNome(data.Nome);
                curso.AlterarDescricao(data.Descricao);
                curso.AlterarCargaHoraria(data.CargaHoraria);
                curso.AlterarPulicoAlvo(data.PublicoAlvo);
                curso.AlterarValorCurso(data.ValorCurso);

            }
            if (data.Id == 0)
            {
                var cursoAdicionado = _cursoRepositorio.Adicionar(curso);
                return cursoAdicionado;
            }

            return curso;
        }
    }
}
