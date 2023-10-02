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

    public Pedido(int numero, string observacion, string nom, string dir, int tel, string refe){
        nro=numero;
        obs=observacion;
        Estado=Estados.Pendiente;
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