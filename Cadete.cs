namespace claseCadetes;
using clasePedido;
using System.Linq;

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
        int entregados=0;
        foreach (var item in pedidos)
        {
            if (item.Estado == Estados.Entregado)
            {
                entregados= entregados + 1;
            }
        }
        return entregados * 500;
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
}