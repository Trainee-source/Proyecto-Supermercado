using System.Data;
using ENTIDADES;
using DAO;

namespace NEGOCIO
{
    public class negCarrito
    {
        daoCarrito asd = new daoCarrito();
        
        public DataTable CrearCarrito()
        {
            return asd.CrearCarrito();
        }
        public void AgregarCarrito(DataTable Carrito, entCarrito lb)
        {
            asd.AgregarCarrito(Carrito, lb);
        }
        public void EliminaCarrito(DataTable Carrito, int pos)
        {
            asd.EliminaCarrito(Carrito, pos);
        }

        public void ModificarCarrito(DataTable Carrito, entCarrito lb)
        {
            asd.ModificarCarrito(Carrito, lb);
        }

        public int MontoCarrito (DataTable Carrito)
        {
            return asd.MontoCarrito(Carrito);
        }

        public void ConfirmarCompra(DataTable Carrito, entUsuario obj, entTarjeta tar)
        {
            asd.AgregarVenta(Carrito, obj, tar);
            asd.AgregarDetalle(Carrito, obj);
        }

        public void ModificarRecompra(DataTable Carrito, entCarrito obj)
        {
            asd.ModificarRecompra(Carrito, obj);
        }
    }
}
