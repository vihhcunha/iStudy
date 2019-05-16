using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iStudy.Model;
using SQLite;

namespace iStudy.ModeloBanco
{
    class MateriaCRUD
    {
        string Pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CriarBancoDeDadosMaterias()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Materias.db")))
                {
                    conexao.CreateTable<ModeloMateria>();
                    var verificarTamanho = GetMaterias();
                    
                    if (verificarTamanho.Count == 0)
                    {
                        var primeiraMateria = new ModeloMateria();
                        primeiraMateria.NomeMateria = "Primeira Matéria";
                        primeiraMateria.ConteudoMateria = "Um exemplo de matéria";
                        InserirMateria(primeiraMateria);
                    }
                    conexao.CreateTable<ModeloMateria>();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CriarBancoDeDadosEventos()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Eventos.db")))
                {
                    conexao.CreateTable<ModeloEventos>();

                    var verificarTamanho = GetEventos();

                    if (verificarTamanho.Count == 0)
                    {
                        var primeiroEvento = new ModeloEventos();
                        primeiroEvento.DataEvento = DateTime.Today.ToString("dd/MM/yyyy");
                        primeiroEvento.DescEvento = "Seu primeiro evento marcado";
                        primeiroEvento.NomeEvento = "#1 - Primeiro Evento!";
                        InserirEvento(primeiroEvento);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool InserirMateria(ModeloMateria materia)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Materias.db")))
                {
                    var nome = conexao.Query<ModeloMateria>("Select NomeMateria from ModeloMateria where NomeMateria = '" + materia.NomeMateria + "';");

                    if (nome.Count == 0)
                    {
                        conexao.Insert(materia);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InserirEvento(ModeloEventos evento)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Eventos.db")))
                {
                    var nome = conexao.Query<ModeloEventos>("Select NomeEvento from ModeloEventos where NomeEvento = '" + evento.NomeEvento + "';");

                    if (nome.Count == 0)
                    {
                        conexao.Insert(evento);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ModeloMateria> GetMaterias()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Materias.db")))
                {
                    return conexao.Table<ModeloMateria>().ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<ModeloMateria> GetMateria(string nomeMateria)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Materias.db")))
                {
                    return conexao.Query<ModeloMateria>("Select ConteudoMateria from ModeloMateria where NomeMateria = '" + nomeMateria+"';");
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ModeloEventos> GetEventos()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Eventos.db")))
                {
                    return conexao.Table<ModeloEventos>().ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<ModeloEventos> GetEventosByName()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Eventos.db")))
                {
                    List<ModeloEventos> list = conexao.Table<ModeloEventos>().ToList(); 
                    return list = list.OrderBy(c => c.NomeEvento).ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<ModeloEventos> GetEventosByDecrescent()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Eventos.db")))
                {
                    List<ModeloEventos> list = conexao.Table<ModeloEventos>().ToList();

                    return list = list.OrderByDescending(c => Convert.ToDateTime(c.DataEvento)).ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<ModeloEventos> GetEventosByCrescent()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Eventos.db")))
                {
                    List<ModeloEventos> list = conexao.Table<ModeloEventos>().ToList();

                    return list = list.OrderBy(c => Convert.ToDateTime(c.DataEvento)).ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool AtualizarMateria(ModeloMateria materia)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Materias.db")))
                {
                    conexao.Query<ModeloMateria>("UPDATE ModeloMateria set ConteudoMateria=? Where NomeMateria=?", materia.ConteudoMateria, materia.NomeMateria);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool AtualizarEvento(ModeloEventos evento)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Eventos.db")))
                {
                    conexao.Query<ModeloMateria>("UPDATE ModeloEventos set NomeEvento=?,DataEvento=?, DescEvento Where NomeMateria=?", evento.NomeEvento, evento.DataEvento, evento.DescEvento);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeletarMateria(ModeloMateria materia)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Materias.db")))
                {
                    conexao.Delete(materia);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeletarEvento(ModeloEventos evento)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(Pasta, "Eventos.db")))
                {
                    conexao.Delete(evento);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
