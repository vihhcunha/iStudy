using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace iStudy.ModeloBanco
{
    class ModeloEventos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NomeEvento { get; set; }
        public string DataEvento { get; set; }
        public string DescEvento { get; set; }
    }
}
