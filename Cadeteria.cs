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
    public int NroUltimoPedido { get => nroUltimoPedido; set => nroUltimoPedido = value; }
    internal List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

    public Cadeteria(string nom, int tel)
    {
        Nombre=nom;
        telefono = tel;
        ListaCadetes = new List<Cadete>();
        NroUltimoPedido = 0;
    }
    public void AgregarCadete(string nombre, int telefono, string direccion){
        int n = ListaCadetes.Count();
        Cadete nuevo = new Cadete(n, nombre, direccion, telefono);
        ListaCadetes.Add(nuevo);
    }

    public Pedido CreaPedido( string obrservacion, string nom, string dir, int tel, string refe){
        int nro = NroUltimoPedido+1;
        Pedido nuevo = new Pedido(nro, obrservacion, nom, dir, tel, refe);
        NroUltimoPedido++;
        return nuevo;
    }

    public void AsignarPedido(Pedido mover, int idCadete){
        Cadete cadete =  ListaCadetes.FirstOrDefault(l=> l.Id == idCadete);
        if (cadete != null)
        {
            cadete.AgregarPedido(mover);
        }else
        {
            Console.WriteLine("error cadete insexistente");
        }
    }

    public void MoverPedido(int idCadeteRemover, int idCadeteAsignar, int nroPedido){
        Cadete cadete =  ListaCadetes.FirstOrDefault(l=> l.Id == idCadeteRemover);
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
        ListaCadetes=list;
    }
   public void GuardarDatosCSV()
    {
        string directorio = Directory.GetCurrentDirectory();
        string archivo = Path.Combine(directorio, "Cadeteria.cvs");
        using (StreamWriter writer = new StreamWriter(archivo))
        {
            writer.WriteLine($"Nombre,Telefono,NumeroUltimoPedido");
            writer.WriteLine($"{Nombre},{telefono},{NroUltimoPedido}");
        }
        Cadete.GuardarDatosCadetes(ListaCadetes);
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
                        NroUltimoPedido = nroUltimoPedido
                    };
                }
            }
        }
        List<Cadete> lista = Cadete.RecuperarDatosCadetes();
        cadeteria.asignarLista(lista);
        return cadeteria;
    }
}