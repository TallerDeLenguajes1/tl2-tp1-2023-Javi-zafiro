namespace clasesCadeteria;
using claseCadetes;
using clasePedido;

class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listaCadetes = null;
    private int nroUltimoPedido;

    public string Nombre { get => nombre; set => nombre = value; }

    public Cadeteria(string nom, int tel)
    {
        Nombre=nom;
        telefono = tel;
        listaCadetes = new List<Cadete>();
        nroUltimoPedido = 0;
    }
    public void AgregarCadete(string nombre, int telefono, string direccion){
        int n = listaCadetes.Count();
        Cadete nuevo = new Cadete(n, nombre, direccion, telefono);
        listaCadetes.Add(nuevo);
    }

    public void CreaPedido(int idCadete, string obrservacion){
        Cadete cadete =  listaCadetes.FirstOrDefault(l=> l.Id == idCadete);
        if (cadete != null)
        {
            int nro = nroUltimoPedido+1;
            Pedido nuevo = new Pedido(nro, obrservacion);
            cadete.AgregarPedido(nuevo);
            nroUltimoPedido++;
        }else
        {
            Console.WriteLine("error cadete insexistente");
        }
    }

    private void AsignarPedido(Pedido mover, int idCadete){
        Cadete cadete =  listaCadetes.FirstOrDefault(l=> l.Id == idCadete);
        if (cadete != null)
        {
            cadete.AgregarPedido(mover);
        }else
        {
            Console.WriteLine("error cadete insexistente");
        }
    }

    public void MoverPedido(int idCadeteRemover, int idCadeteAsignar, int nroPedido){
        Cadete cadete =  listaCadetes.FirstOrDefault(l=> l.Id == idCadeteRemover);
        if (cadete != null)
        {
            Pedido mover = cadete.MoverPedido(nroPedido);
            if (mover != null)
            {
                AsignarPedido(mover, idCadeteAsignar);
            }
        }else
        {
            Console.WriteLine("error cadete insexistente");
        }

    }
    private void asignarLista(List<Cadete> list){
        listaCadetes=list;
    }
   public void GuardarDatosCSV()
    {
        string directorio = Directory.GetCurrentDirectory();
        string archivo = Path.Combine(directorio, "Cadeteria.cvs");
        using (StreamWriter writer = new StreamWriter(archivo))
        {
            writer.WriteLine($"Nombre,Telefono,NumeroUltimoPedido");
            writer.WriteLine($"{Nombre},{telefono},{nroUltimoPedido}");
        }
        Cadete.GuardarDatosCadetes(listaCadetes);
    }

    public static Cadeteria RecuperarDatosCadeteria()
    {
        string directorio = Directory.GetCurrentDirectory();
        string archivo = Path.Combine(directorio, "Cadeteria.cvs");
        Cadeteria cadeteria = null;

        if (File.Exists(archivo))
        {
            string[] lineas = File.ReadAllLines(archivo);

            if (lineas.Length > 1)
            {
                var propiedades = lineas[0].Split(',');
                var valores = lineas[1].Split(',');

                if (propiedades.Length == valores.Length)
                {
                    // Obtener los valores necesarios
                    string nombre = valores[0];
                    int telefono = int.Parse(valores[1]);
                    int nroUltimoPedido = int.Parse(valores[2]);

                    // Crear una instancia de Cadeteria con los valores recuperados
                    cadeteria = new Cadeteria(nombre, telefono)
                    {
                        nroUltimoPedido = nroUltimoPedido
                    };
                }
            }
        }
        List<Cadete> lista = Cadete.RecuperarDatosCadetes();
        cadeteria.asignarLista(lista);
        return cadeteria;
    }
}