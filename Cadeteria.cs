using claseCadetes;
using clasePedido;

class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listaCadetes = null;

    public Cadeteria(string nom, int tel)
    {
        nombre=nom;
        telefono = tel;
        listaCadetes = new List<Cadete>();
    }
    public void AgregarCadete(string nombre, int telefono, string direccion){
        int n = listaCadetes.Count();
        Cadete nuevo = new Cadete(n, nombre, direccion, telefono);
        listaCadetes.Add(nuevo);
    }

    public void CreaPedido(int idCadete, int nro, string obrservacion){
        Pedido nuevo = new Pedido(nro, obrservacion);
        
    }
}