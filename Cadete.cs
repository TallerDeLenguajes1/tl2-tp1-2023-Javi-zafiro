namespace claseCadetes;
using clasePedido;
using System.Linq;

class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    List<Pedido> pedidos= null;

    public Cadete(int n, string nom, string dir, int tel)
    {
        id=n;
        nombre=nom;
        direccion=dir;
        telefono=tel;
        pedidos=new List<Pedido>();
    }

    public int Id { get => id; set => id = value; }

    public void AgregarPedido(Pedido nuevo){
        pedidos.Add(nuevo);
    }

    public Pedido MoverPedido(int numero){
        Pedido borrar = pedidos.FirstOrDefault(p=> p.Nro == numero);
        pedidos.Remove(borrar);
        return borrar;
    }
}