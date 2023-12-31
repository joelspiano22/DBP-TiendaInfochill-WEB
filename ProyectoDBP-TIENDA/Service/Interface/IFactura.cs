﻿using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IFactura
    {
        IEnumerable<TbFactura> GetAllFactura();
        TbFactura GetFactura(int id);
        void Add(TbFactura factura);
        TbFactura CrearFactura(int codUsuario);
    }
}
