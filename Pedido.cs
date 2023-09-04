namespace clasePedido;
using claseCliente;

enum Estados
{
    Pendiente, Entregado
}
class Pedido
{
    private int nro;
    private string obs;
    private Cliente nuevo=null;
    private Estados estado ;

    
    public int Nro{get=> nro; set=> nro=value;}
    public Estados Estado { get => estado; set => estado = value; }

    public Pedido(int numero, string observacion){
        nro=numero;
        obs=observacion;
        Estado=Estados.Pendiente;
        Console.WriteLine("vamos a agregar los datos del cliente");
        Console.WriteLine("nombre del cliente:");
        string nom = Console.ReadLine();
        Console.WriteLine("direccion:");
        string dir = Console.ReadLine();
        Console.WriteLine("telefono:");
        int tel;
        int.TryParse(Console.ReadLine(), out tel);
        Console.WriteLine("alguna referencia de la direccion:");
        string refe= Console.ReadLine();
        nuevo=new Cliente(nom, dir, tel, refe);
    }

    public void VerDireccionCliente(){
        nuevo.VerDireccion();
    }
    public void VerDatosCliente(){
        nuevo.VerDatos();
    }

    public void CambiarEstado(){
        if (Estado== Estados.Pendiente)
        {
            Estado=Estados.Entregado;
        }else
        {
            Estado=Estados.Pendiente;
        }
    }
}