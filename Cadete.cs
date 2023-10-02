namespace claseCadetes;
using clasePedido;
using System.Linq;
using System.IO;


class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> pedidos= null;

    public Cadete(int n, string nom, string dir, int tel)
    {
        id=n;
        nombre=nom;
        direccion=dir;
        telefono=tel;
        this.pedidos=new List<Pedido>();
    }

    public int Id { get => id; set => id = value; }

    public void AgregarPedido(Pedido nuevo){
        pedidos.Add(nuevo);
    }

    public Pedido MoverPedido(int numero){
        Pedido borrar = pedidos.FirstOrDefault(p=> p.Nro == numero);
        if (borrar != null)
        {
            pedidos.Remove(borrar);
        }else
        {
            Console.WriteLine("pedido no encontrado");
        }
        return borrar;
    }

    public float JornalACobrar(){
        int entregados=totalEntregados();
        return entregados * 500;
    }

    public float promedioEnvios(){
        int entregados=totalEntregados();
        return entregados / pedidos.Count;
    }

    public int totalEntregados(){
        int entregados=0;
        foreach (var item in pedidos)
        {
            if (item.Estado == Estados.Entregado)
            {
                entregados= entregados + 1;
            }
        }
        return entregados;
    }

    public void CambiarEstado(int num){
        Pedido cambiar =  pedidos.FirstOrDefault(p=> p.Nro == num);
        if (cambiar != null)
        {
            cambiar.CambiarEstado();
        }else
        {
            Console.WriteLine("pedido no encontrado");
        }
    }

    public void VerDireccionDePedido(int numeroDePedido){
        Pedido pedidoAEntregar =  pedidos.FirstOrDefault(p=> p.Nro == numeroDePedido);
        if (pedidoAEntregar != null)
        {
            pedidoAEntregar.VerDireccionCliente();
        }else
        {
            Console.WriteLine("pedido no encontrado");
        }
    }

    public void VerClienteEntregarPedido(int numeroDePedido){
        Pedido pedidoAEntregar =  pedidos.FirstOrDefault(p=> p.Nro == numeroDePedido);
        if (pedidoAEntregar != null)
        {
            pedidoAEntregar.VerDatosCliente();
        }else
        {
            Console.WriteLine("pedido no encontrado");
        }
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