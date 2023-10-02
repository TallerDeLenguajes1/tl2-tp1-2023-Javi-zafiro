namespace Cadeterias;
using System.IO;


class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;

    public Cadete(int n, string nom, string dir, int tel)
    {
        id=n;
        nombre=nom;
        direccion=dir;
        telefono=tel;
    }

    public int Id { get => id; set => id = value; }


    public void VerDireccionDePedido(int numeroDePedido){

    }

    public void VerClienteEntregarPedido(int numeroDePedido){

    }

    public static void GuardarDatosCadetes( List<Cadete> datos)
    {
        string directorio = Directory.GetCurrentDirectory();
        string archivo = Path.Combine(directorio, "Cadetes.cvs");

        if (File.Exists(archivo))
        {
            List<Cadete> datosExistentes = RecuperarDatosCadetes();
            datosExistentes.AddRange(datos);
           using (StreamWriter writer = new StreamWriter(archivo))
            {
                // Escribir encabezados
                writer.WriteLine("Id,Nombre,Direccion,Telefono");

                foreach (var cadete in datosExistentes)
                {
                    // Escribir los datos de cada cadete
                    writer.WriteLine($"{cadete.id},{cadete.nombre},{cadete.direccion},{cadete.telefono}");
                }
            }
        }else
        {
            using (StreamWriter writer = new StreamWriter(archivo))
            {
                // Escribir encabezados
                writer.WriteLine("Id,Nombre,Direccion,Telefono");

                foreach (var cadete in datos)
                {
                    // Escribir los datos de cada cadete
                    writer.WriteLine($"{cadete.id},{cadete.nombre},{cadete.direccion},{cadete.telefono}");
                }
            }
        }
    }

    public static List<Cadete> RecuperarDatosCadetes()
    {
        string directorio = Directory.GetCurrentDirectory();
        string archivo = Path.Combine(directorio, "Cadetes.cvs");
        List<Cadete> cadetes = new List<Cadete>();

        if (File.Exists(archivo))
        {
            string[] lineas = File.ReadAllLines(archivo);

            if (lineas.Length > 1)
            {
                var propiedades = lineas[0].Split(',');

                for (int i = 1; i < lineas.Length; i++)
                {
                    var valores = lineas[i].Split(',');
                    Cadete cadete = new Cadete(
                        int.Parse(valores[0]),
                        valores[1],
                        valores[2],
                        int.Parse(valores[3])
                    );

                    cadetes.Add(cadete);
                }
            }
        }else
        {
            Console.WriteLine("error no se encontro el archivo");
        }

        return cadetes;
    }
}