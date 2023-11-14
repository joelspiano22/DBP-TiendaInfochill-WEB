﻿using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class DetalleFacturaRepository : IDetalleFactura
    {
        private BdInfochill bdChill = new BdInfochill();

        public IEnumerable<TbDetalleFactura> GetAllDetalleFacturas()
        {
            return bdChill.TbDetalleFacturas.ToList();
        }
    }
}
