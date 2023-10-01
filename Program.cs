using Cadeterias;

using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Cadeteria cadeteria = Cadeteria.RecuperarDatosCadeteria();
        if (cadeteria!=null)
        {
            Console.WriteLine("Interfas de Cadeteria");
            int menu=-1;
            bool salida=true;
            List<Pedido> listaPedidos = new List<Pedido>();
            do
            {
                Console.WriteLine("que desea realizar?");
                Console.WriteLine("1.Alta Pedidos");
                Console.WriteLine("2.Asignar Pedidos");
                Console.WriteLine("3.Cambiar de Estado Pedidos");
                Console.WriteLine("4.Reasignar Pedido");
                Console.WriteLine("5.Terminar Jornada");
                int.TryParse(Console.ReadLine(), out menu);

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Alta Pedido nro "+cadeteria.NroUltimoPedido);
                        Console.WriteLine("Cliente: ");
                        Console.WriteLine("Nombre: ");
                        string nom = Console.ReadLine();
                        Console.WriteLine("Direccion: ");
                        string dir = Console.ReadLine();
                        Console.WriteLine("Referencia: ");
                        string refe = Console.ReadLine();
                        Console.WriteLine("Telefono: ");
                        int tel;
                        int.TryParse(Console.ReadLine(), out tel);
                        Console.WriteLine("Aguna observacion del pedido:");
                        string obs=Console.ReadLine();
                        Pedido nuevo=cadeteria.CreaPedido(obs, nom, dir, tel, refe);
                        listaPedidos.Add(nuevo);
                    break;
                    case 2:
                        Console.WriteLine("Asignar Pedido");
                        Console.WriteLine("ingrese el numero de pedido");
                        int nro;
                        int.TryParse(Console.ReadLine(), out nro);
                        Pedido encontrado = listaPedidos.FirstOrDefault(p=> p.Nro == nro);
                        Console.WriteLine("ingrese el id del cadete");
                        int id;
                        int.TryParse(Console.ReadLine(), out id);
                        cadeteria.AsignarPedido(encontrado, id);
                    break;
                    case 3:
                        Console.WriteLine("Cambiar Estado de Pedido");
                        Console.WriteLine("primero ingrese el id del cadete al que se le asigno el pedido");
                        int idCadete;
                        int.TryParse(Console.ReadLine(), out idCadete);
                        Cadete cadeteEncontrado = cadeteria.ListaCadetes.FirstOrDefault(p=> p.Id == idCadete);
                        Console.WriteLine("ingrese le nro del pedido");
                        int nroPedido;
                        int.TryParse(Console.ReadLine(), out nroPedido);
                        cadeteEncontrado.CambiarEstado(nroPedido);
                    break;
                    case 4:
                        Console.WriteLine("reasignar un pedido");
                        Console.WriteLine("ingrese el id del cadete que tiene el pedido");
                        int idCadeteRemover;
                        int.TryParse(Console.ReadLine(), out idCadeteRemover);
                        Console.WriteLine("ingrese el nro del pedido");
                        int nroPedidoAMover;
                        int.TryParse(Console.ReadLine(), out nroPedidoAMover);
                        Console.WriteLine("ingrese el id del cadete que tiene el pedido");
                        int idCadeteAsignar;
                        int.TryParse(Console.ReadLine(), out idCadeteAsignar);
                        cadeteria.MoverPedido(idCadeteRemover, idCadeteAsignar, nroPedidoAMover);
                    break;
                    case 5:
                        salida=false;
                        float total=0;
                        Console.WriteLine("informe final");
                        foreach (Cadete item in cadeteria.ListaCadetes)
                        {
                            Console.WriteLine("informe del cadete "+ item.Id);
                            Console.WriteLine("el total de envios es: "+item.totalEntregados());
                            Console.WriteLine("el total a cobrar es: "+ item.JornalACobrar());
                            Console.WriteLine("el promedio de envios es : "+ item.promedioEnvios());
                            total=total+item.JornalACobrar();
                        }
                        Console.WriteLine("el total del dia es: "+ total);
                    break;
                    default:
                    Console.WriteLine("error");
                    break;
                }
            } while (salida);
            
        }else{
            Console.WriteLine("error");
        }
    }
}