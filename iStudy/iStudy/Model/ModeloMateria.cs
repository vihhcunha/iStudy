using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace iStudy.Model
{
    class ModeloMateria
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string NomeMateria { get; set; }
        public string ConteudoMateria { get; set; }
    }
}
