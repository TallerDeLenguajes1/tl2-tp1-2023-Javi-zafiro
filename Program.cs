using Cadeterias;

using System.Linq;

internal class Program
{
    private static void Main(string[] args){
        AccesoADatos accesoADatos;
        accesoADatos = new AccesoJSON("Cadetes.json", "Cadeteria.json");
        accesoADatos.GuardarNuevoCadete(1,"javier","san martin","1234");
        accesoADatos.GuardarNuevoCadete(2,"celeste","belgrano","1234");
        accesoADatos.GuardarNuevoCadete(3,"martin","sarmiento","1234");
        accesoADatos.GuardarNuevaCadeteria("PedidosYa", "381093847");
    }
}