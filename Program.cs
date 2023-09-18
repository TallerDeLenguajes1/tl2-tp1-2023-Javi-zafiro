using clasesCadeteria;
using claseCadetes;
internal class Program
{
    private static void Main(string[] args)
    {
        Cadeteria nueva = Cadeteria.RecuperarDatosCadeteria();
        if (nueva!=null)
        {
            Console.WriteLine(nueva.Nombre);
        }else{
            Console.WriteLine("error");
        }
    }
}