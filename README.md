2.A

*)
cadeteria -agregacion- cadete
cadete -agregacion- pedido
pedido -composicion- cliente

*)
cadeteria: CrearPedido, AgregarCadete, MoverPedido
cadete: AgregarPedido, EliminarPedido, CambiarEstado

