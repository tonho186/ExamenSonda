using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenSonda.Code.Comunes
{
    public class DtRequest
    {
        /* Propiedades */
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public SearchT Search { get; set; }
        public List<OrderT> Order { get; set; }
        public List<ColumnT> Columns { get; set; }

        /* Constructor */
        public DtRequest()
        {
            SearchT Search = new SearchT();
            List<OrderT> Order = new List<OrderT>();
            List<ColumnT> Columns = new List<ColumnT>();
        }

        /* Clases */
        public class SearchT
        {
            public string Value { get; set; }
            public Boolean Regex { get; set; }
        }
        public class OrderT
        {
            public int Column { get; set; }
            public string Dir { get; set; }
        }
        public class ColumnT
        {
            public string Data { get; set; }
            public string Name { get; set; }
            public Boolean Searchable { get; set; }
            public Boolean Orderable { get; set; }
            public SearchT Search { get; set; }
        }
    }
}