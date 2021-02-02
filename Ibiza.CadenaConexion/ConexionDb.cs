namespace Ibiza.CadenaConexion
{
    public static class ConexionDb
    {
        private const string Servidor = @"LAPTOP-31N6BQDF\SQLEXPRESS";
        private const string BaseDatos = "IbizaShowroomDemoDb";

        public static string ObtenerCadenaConexionWin => $"Data Source={Servidor}; " +
                                                      $"Initial Catalog={BaseDatos}; " +
                                                      $"Integrated Security = true";
    }
}
