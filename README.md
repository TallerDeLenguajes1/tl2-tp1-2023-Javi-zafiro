2.A

*)
cadeteria -agregacion- cadete
cadete -agregacion- pedido
pedido -composicion- cliente

*)
cadeteria: CrearPedido, AgregarCadete, MoverPedido, AsignarPedido
cadete: AgregarPedido, MoverPedido, CambiarEstado, JornalACobrar, VerDireccionDePedido, VerClienteEntregarPedido

*)
todos los atributos deben ser privados, se acceden a ellos por medio de las propiedades si fuera necesario, en este caso incluso hay atributos a los que no se puede acceder ni por propiedades. la mayoria de los metodos son publicos, el unico que es privado es el de AsignarPedido de la clase cadeteria.

*)
public Cliente (string nom, string dir, int tel, string refe){
    nombre=nom;
    direccion=dir;
    telefono=tel;
    referenciaDireccion=refe;
}

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

public Cadete(int n, string nom, string dir, int tel)
{
    id=n;
    nombre=nom;
    direccion=dir;
    telefono=tel;
    this.pedidos=new List<Pedido>();
}

public Cadeteria(string nom, int tel)
{
    nombre=nom;
    telefono = tel;
    listaCadetes = new List<Cadete>();
    nroUltimoPedido = 0;
}


*)
es dificil responder ya que a medida que voy progresando y se me ocurren nuevas formas de hacer las cosas las voy implemnetando, en otras palabras lo ultimo subido a este repositorio es la ultima forma que se ocurrio de implementarlo