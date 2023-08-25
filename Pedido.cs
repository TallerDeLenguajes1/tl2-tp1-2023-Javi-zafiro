namespace clasePedido;
using claseCliente;

class Pedido
{
    private int nro;
    private string obs;
    private Cliente nuevo=null;
    private string estado;

    public string Estado{get=> estado; set=> estado=value;}
    public int Nro{get=> nro; set=> nro=value;}

    public Pedido(int numero, string observacion, string est, string nom, string dir, int tel, string refe){
        nro=numero;
        obs=observacion;
        estado=est;
        nuevo=new Cliente(nom, dir, tel, refe);
    }

    public void VerDireccionCliente(){
        Console.WriteLine(nuevo.Direccion);
        Console.WriteLine(nuevo.ReferenciaDireccion);
    }
    public void VerDatosCliente(){
        Console.WriteLine(nuevo.Nombre);
        Console.WriteLine(nuevo.Telefono);
    }
}