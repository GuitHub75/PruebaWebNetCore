using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using web_net_core.Models;

namespace web_net_core.Aplicacion
{
    public class UsuariosApp
    {
        private readonly IDbConnection _conecction;

        public UsuariosApp(IDbConnection connection)
        {
            _conecction = connection;
        }
        //Hacemos un select a la base de datos
        public List<UsuariosEN> GetAll()
        {
            return _conecction.Query<UsuariosEN>("SELECT * FROM Usuarios").ToList();
        }
    }
}
