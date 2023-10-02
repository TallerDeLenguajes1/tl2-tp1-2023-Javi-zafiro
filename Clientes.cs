namespace claseCliente;


class Cliente
{
    private string nombre;
    private string direccion;
    private int telefono;
    private string referenciaDireccion;

    public Cliente (string nom, string dir, int tel, string refe){
        nombre=nom;
        direccion=dir;
        telefono=tel;
        referenciaDireccion=refe;
    }

    public void VerDireccion(){
        Console.WriteLine(direccion);
        Console.WriteLine(referenciaDireccion);
    }

    public void VerDatos(){
        Console.WriteLine(nombre);
        Console.WriteLine(telefono);
    }
}