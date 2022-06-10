using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityLinqCriandoQueryPoderosas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Listar os gêneros Rock
            var generos = new List<Genero>
            {
                new Genero { Id = 1, Nome = "Rock"},
                new Genero { Id = 2, Nome = "Reggae"},
                new Genero { Id = 3, Nome = "Forró"},
                new Genero { Id = 4, Nome = "Pagode"},
                new Genero { Id = 5, Nome = "Clássica"},
                new Genero { Id = 6, Nome = "Sertanejo"},
                new Genero { Id = 7, Nome = "Samba"}
            };
            foreach (var genero in generos)
            {
                if (genero.Nome.Contains("Rock"))
                {
                    Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
                }
            }


            //select * from generos
            var query = from g in generos
                        where g.Nome.Contains("Rock")
                        select g;

            //Linq = Language Integrated Query = Consulta Integrada à linguagem

            Console.WriteLine();
            foreach (var genero in query)
            {
                Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            }

            //Listar músicas
            var musicas = new List<Musica>
            {
                new Musica{Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1},
                new Musica{Id = 2, Nome = "Cheia de Manias", GeneroId = 7},
                new Musica{Id = 3, Nome = "Amigo apaixonado", GeneroId = 6}
            };

            var musicaQuery = from m in musicas
                              join g in generos on m.GeneroId equals g.Id
                              select new { m, g};

            Console.WriteLine();
            foreach (var musica in musicaQuery)
            {
                Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Nome, musica.g.Nome);
            }

            Console.ReadKey();
        }
    }

    class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int GeneroId { get; set; }
    }
}
