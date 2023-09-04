using claseCadetes;
using clasePedido;

class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listaCadetes = null;
    private int nroUltimoPedido;

    public Cadeteria(string nom, int tel)
    {
        nombre=nom;
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
}