namespace claseCliente;

enum estados
{
    pendiente, entregado
}

class Cliente
{
    private string nombre;
    private string direccion;
    private int telefono;
    private string referenciaDireccion;

    public string Nombre{get => nombre; set=> nombre=value;}
    public string Direccion{get => direccion; set=> direccion=value;}
    public int Telefono{get => telefono; set=> telefono=value;}
    public string ReferenciaDireccion{get => referenciaDireccion; set=> referenciaDireccion=value;}

    public Cliente (string nom, string dir, int tel, string refe){
        nombre=nom;
        direccion=dir;
        telefono=tel;
        referenciaDireccion=refe;
    }
}